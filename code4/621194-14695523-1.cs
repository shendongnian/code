    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    namespace ConsoleApplication
    {
        class Program
        {
             static void Main(string[] args)
             {
                 var values = new List<string>();
                 values.Add("123");
                 Console.WriteLine(
                     Match(zip => values.Contains(zip.Code)).Count()); // -> 1
                 Console.WriteLine(
                     Match(zip => values.Contains(zip.OtherCode)).Count()); // -> 0
                 Console.Read();
             }
             public static IEnumerable<ZipCode> Match(Expression<Func<ZipCode, bool>> predicate)
             {
                 var table = new List<ZipCode> 
                          { new ZipCode { Code = "123" }, new ZipCode { OtherCode = "234" } }
                    .AsQueryable();
                 return (from zipCode in table.Where(predicate)
                        select zipCode).Distinct();
             }
         }
         public class ZipCode
         {
             public string Code { get; set; }
             public string OtherCode { get; set; }
         }
    }
