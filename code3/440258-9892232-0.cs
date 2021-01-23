    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication7
    {
       class Customer
       {
          public int CustomerId;
       }
    
       class TestObject
       {
          public List<Customer> Invoice;
          public int Id;
       }
    
       class Program
       {
          static void Main(string[] args)
          {
             Expression<Func<TestObject, bool>> expression = t => t.Invoice.Any(i => i.CustomerId == t.Id);
    
          }
       }
    }
