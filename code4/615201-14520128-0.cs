    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            public static void Main()
            {
                foreach (var date in DateRange(new DateTime(2013, 01, 25), new DateTime(2013, 01, 31)))
                {
                    Console.WriteLine(date.ToShortDateString());
                }
            }
            public static IEnumerable<DateTime> DateRange(DateTime start, DateTime end)
            {
                for (DateTime date = start; date <= end; date = date.AddDays(1))
                {
                    yield return date;
                }
            }
        }
    }
