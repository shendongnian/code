    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace RegTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string testDate = "3214312402-17-2013143214214";
                Regex rgx = new Regex(@"\d{2}-\d{2}-\d{4}");
                Match mat = rgx.Match(testDate);
                Console.WriteLine(mat.ToString());
                Console.ReadLine();
            }
        }
    }
