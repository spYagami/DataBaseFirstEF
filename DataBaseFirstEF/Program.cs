using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseFirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                // In here the query is being difined

                var query = db.Customers.Where(c => c.CustomerId == "BONAP");

                // the var query is only called when he method "FirstOrDefault()" is called!

                var selectCustomer = query.FirstOrDefault();

                selectCustomer = db.Customers.Where(c => c.CustomerId == "ANTON").FirstOrDefault(); // in here the query is created and executed due to it being an one liner

                var selectedCustomer = db.Customers.Find("BERGS");

                //DEFINITION
                IEnumerable<Customer> query1 =
                    from c in db.Customers
                    where c.City == "London"
                    select c;


                //EXECUTION
                foreach(var v in query1)
                {
                    Console.WriteLine($"Customer {v.ToString()} lives in {v.City}");
                }

                int numCustomersInLondon = query1.Count();

                List<int> myList = new() { 3, 6, 9};

                //query
                var numQuery =
                    from number in myList
                    select number;

                //execute query
                foreach(int number in numQuery)
                {
                    Console.WriteLine(number);
                }

                IEnumerable<Customer> LondonCustomerQuery =
                    from c in db.Customers
                    where c.City == "London"
                    orderby c
                    select c;

                foreach (var c in LondonCustomerQuery)
                {
                    Console.WriteLine(c);
                }


                db.SaveChanges();



                //Console.WriteLine(db.ContextId);

                //foreach(var c in db.Customers)
                //{
                //    Console.WriteLine($"Customer {c.ContactName} has ID: {c.CustomerId} and lives in {c.City}");
                //    Console.WriteLine(c);
                //}
                ////Lamda Expression
                //db.Customers.ToList().ForEach(c => Console.WriteLine(c));

                #region ADD
                //ADD

                //var newCustomer = new Customer
                //{
                //    CustomerId = "BLOGG",
                //    ContactName = "Joe Bloggs",
                //    CompanyName = "ToysRUs"
                //};

                //db.Customers.Add(newCustomer);
                //db.SaveChanges();
                #endregion

                #region SELECT CUSTOMER
                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();

                //selectedCustomer.City = "Paris";

                //db.SaveChanges();

                #endregion

                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();

                //db.Customers.Remove(selectedCustomer);

                //db.SaveChanges();

                //var p = db.Customers.Find("BLOGG");

            }
        }
    }

    public partial class Customer
    { 
        public override string ToString()
        {
            return $"{CustomerId} - {ContactName} - {City}";
        }
    }

}
