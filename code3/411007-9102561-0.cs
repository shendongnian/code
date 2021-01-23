    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                Regex rx = new Regex(@"^-{0,1}\d{0,3}(?:\.{0,1}(?<=\.)\d{0,3})?$");
                List<string> testStrings = new List<string>()
                {
                    "100",
                    "100.100",
                    "1000.0000",
                    "100000",
                    "-1",
                    "-1.234",
                    "--",
                    "100.100ab",
                    "1,234.1",
                    "1,234",
                    "abc",
                    "abc123.123",
                    "abc.def"
                };
                foreach(var str in testStrings)
                {
                    Console.WriteLine(string.Format("{0} = {1}", str, rx.IsMatch(str)));
                }
                Console.ReadLine();
            }
        }
    }
