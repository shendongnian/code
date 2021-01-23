    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication7
    {
       class CTX
       {
          public List<Customer> customer = new List<Customer>();
          public List<Customer> Invoice = new List<Customer>();
       }
    
       class Customer
       {
          public int customerId;
          public int id;
       }
    
       class Program
       {
          static void Main(string[] args)
          {
             CTX ctx = new CTX();
             Expression<Func<Customer, bool>> expression = c => ctx.Invoice.Any(i => i.customerId == c.id);
          }
       }
    }
