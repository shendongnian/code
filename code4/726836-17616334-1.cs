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
                Regex re = new Regex(@"(\d+)|((\d+)\-(\d+))");
                Match m = re.Match(range);
                if (!string.IsNullOrEmpty(m.Groups[2].Value))
                    return m.Groups[1].Value + " to " + m.Groups[2].Value;
                else
                    return m.Groups[1].Value;
            }
        }
    }
