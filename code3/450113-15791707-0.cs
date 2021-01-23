        public static long Average(this IEnumerable<long> longs)
        {
            long count = longs.Count();
            long mean = 0;
            foreach (var val in longs)
            {
                mean += val / count;
            }
            return mean;
        }
        public static DateTime Average(this IEnumerable<DateTime> dates)
        {
            return new DateTime(dates.Select(x => x.Ticks).Average());
        }
