    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                DateTime endDate = new DateTime(2013, 2, 1);
                DateTime begDate = new DateTime(2012, 7, 1);
                foreach (DateTime date in MonthsInRange(begDate, endDate))
                {
                    Console.WriteLine(date.ToString("M\\/yyyy"));
                }
            }
            public static IEnumerable<DateTime> MonthsInRange(DateTime start, DateTime end)
            {
                for (DateTime date = start; date <= end; date = date.AddMonths(1))
                {
                    yield return date;
                }
            }
        }
    }
