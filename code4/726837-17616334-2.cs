    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RangeTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "1,2,3,1-5,10-15,100-200";
                string[] ranges = str.Split(',');
                foreach (string range in ranges)
                {
                    Console.WriteLine(GetRange(range.Trim()));
                }
                Console.Read();
            }
    
            static string GetRange(string range)
            {
                string[] rng = range.Split('-');
                if (rng.Length == 2)
                    return rng[0] + " to " + rng[1];
                else
                    return rng[0];
            }
        }
    }
