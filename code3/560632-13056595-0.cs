    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "55555>>><<[1234]<>>>788";
    
                Regex r = new Regex(@"\[(\d*)\]");
                Match match = r.Match(str);
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
