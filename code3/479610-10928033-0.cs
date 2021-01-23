    using System;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime startDate = DateTime.Parse("2011-01-01 00:00:00");
                DateTime endDate = DateTime.Parse("2011-01-03 01:01:03");
                TimeSpan elapsed = endDate - startDate;
                string result = string.Format("{0:d2}:{1:d2}:{2:d2}", elapsed.Days*24 + elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
                Console.WriteLine(result);
            }
        }
    }
