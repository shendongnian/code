    using System;
    using System.Globalization;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("da-DK");
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
                string test = "aaaaaaaaaaaaaaaaaaaa";
                Console.WriteLine(test.StartsWith("aa"));
                Console.WriteLine(test.StartsWith("aaa"));
                Console.WriteLine(test.StartsWith("aaaa"));
                Console.WriteLine(test.StartsWith("aaaaa"));
                Console.WriteLine(test.StartsWith("aaaaaa"));
                Console.WriteLine(test.StartsWith("aaaaaaa"));
            }
        }
    }
