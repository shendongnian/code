    using System;
    using System.Text.RegularExpressions;
    namespace SampleNamespace
    {
        public class SampleClass
        {
            public static void Main()
            {
                string line = "1+3^4^5  10+3+4*5+2^5^6^7";              
                System.Console.WriteLine(line);
                line = Regex.Replace(line, @"(\d+\^){2,}", "0");
                System.Console.WriteLine(line);
            }
        }
    }
