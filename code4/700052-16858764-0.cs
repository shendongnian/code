    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public static void Main(string[] args)
        {
            string input = "brbrbr";
            Regex one = new Regex(@".*(.+).*\1.*\1.*");
            for (int i = 0; i < 5; i++)
            {
                bool x = one.IsMatch(input); //warm regex up
            }
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                bool x = one.IsMatch(input);
            }
            sw.Stop();
            Console.WriteLine("Non-consecutive: {0}ms", sw.ElapsedMilliseconds);
            Regex two = new Regex(@".*(.+)\1\1.*");
            for (int i = 0; i < 5; i++)
            {
                bool x = two.IsMatch(input); //warm regex up
            }
            Stopwatch sw2 = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                bool x = two.IsMatch(input);
            }
            sw.Stop();
            Console.WriteLine("Consecutive: {0}ms", sw2.ElapsedMilliseconds);
            Console.ReadKey(true);
        }
    }
