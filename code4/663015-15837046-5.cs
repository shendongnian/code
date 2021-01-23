    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Datum
        {
            public DateTime DateTime;
            public double Value;
        }
        public static class EnumerableDatumExt
        {
            public static double Average(this IEnumerable<Datum> @this)
            {
                return @this.Average(datum => datum.Value);
            }
            public static IEnumerable<Datum> InTimeRange(this IEnumerable<Datum> @this, DateTime start, DateTime end)
            {
                return from datum in @this
                       where (start <= datum.DateTime && datum.DateTime <= end)
                       select datum;
            }
            public static IEnumerable<Datum> ForEach(this IEnumerable<Datum> @this, DayOfWeek targetDayOfWeek)
            {
                return from datum in @this
                       where datum.DateTime.DayOfWeek == targetDayOfWeek
                       select datum;
            }
        }
        static class Program
        {
            static void Main()
            {
                var start  = new DateTime(2012, 01, 01);
                var end    = new DateTime(2012, 01, 31);
                var data   = createTestData(start);
                double average = data.ForEach(DayOfWeek.Monday).InTimeRange(start, end).Average();
                Console.WriteLine(average);
            }
            private static IEnumerable<Datum> createTestData(DateTime start)
            {
                var result = new List<Datum>();
                var oneDay = TimeSpan.FromDays(1);
                for (int i = 0; i < 20; ++i)
                {
                    start += oneDay;
                    result.Add(new Datum {DateTime = start, Value = i});
                }
                return result;
            }
        }
    }
