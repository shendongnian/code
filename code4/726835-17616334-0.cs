    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace RegexRangeTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "1-5,10-15,100-200";
                string[] ranges = str.Split(',');
                foreach (string range in ranges)
                {
                    Console.WriteLine(range.Trim());
                    Console.WriteLine(GetRange(range.Trim()));
                }
                Console.Read();
            }
    
            static string GetRange(string range)
            {
                Regex re = new Regex(@"(\d+)\-(\d+)");
                Match m = re.Match(range);
    
                return m.Groups[1] + " to " + m.Groups[2];
            }
        }
    }
