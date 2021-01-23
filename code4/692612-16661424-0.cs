    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace SortTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                //your objects
                List<string> newList = new List<string>() { "10S", "XS", "80", "5S", "160", "40S", "80S", "STD", "40", "XXS" };
    
                //filter the stuff you want first, and then sort them from small to big
                var sQuery = newList.Where(p => p.EndsWith("s", StringComparison.CurrentCultureIgnoreCase)).OrderBy(p => p);
                var numQuery = newList.Where(p => Regex.IsMatch(p, "^[0-9]+$", RegexOptions.Singleline)).OrderBy(p => p);
                var otherQuery = newList.AsQueryable().Where(p => !sQuery.Contains(p) && !numQuery.Contains(p));
    
                //get the result, add the sorts
                List<string> resultList = new List<string>();
                resultList.AddRange(numQuery);
                resultList.AddRange(sQuery);
                resultList.AddRange(otherQuery);
    
                //print them out
                Console.Write(string.Join(",", resultList.ToArray()));
    
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
