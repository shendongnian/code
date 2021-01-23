    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication7
    {
       class CTX
       {
          public List<Customer> Invoices = new List<Customer>();
       }
    
       class Customer
       {
          public int id;
          public static bool HasMatchingIds(Customer first, Customer second) { return true; }
       }
    
       class Program
       {
          static void Main(string[] args)
          {
             CTX ctx = new CTX();
    
             Expression<Func<Customer, bool>> expression = cust => ctx.Invoices.Any(customer => Customer.HasMatchingIds(customer, cust));
          }
       }
    }
    
