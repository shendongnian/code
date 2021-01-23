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
