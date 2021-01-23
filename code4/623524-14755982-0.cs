    public static class DateTimeExtensions
    {
        public static DateTime RoundToNearestInterval(this DateTime dateTime, TimeSpan interval)
        {
            // Adapted from http://stackoverflow.com/questions/1393696/c-rounding-datetime-objects
            // do the rounding
            var intervalTicks = interval.Ticks;
            var ticks = (dateTime.Ticks + (intervalTicks / 2) + 1) / intervalTicks;
            var totalTicks = ticks * intervalTicks;
            // make sure the result is not to low
            if (totalTicks < 0)
                totalTicks = 0;
            // make sure the result is not to high
            const long maxTicks = 0x2bca2875f4373fffL; // DateTime.MaxTicks
            if (totalTicks > maxTicks)
                totalTicks = maxTicks;
            // return the new date from the result
            return new DateTime(totalTicks, dateTime.Kind);
        }
        public static bool EqualsRounded(this DateTime x, DateTime y)
        {
            return x.EqualsRounded(y, TimeSpan.FromSeconds(1));
        }
        public static bool EqualsRounded(this DateTime x, DateTime y, TimeSpan interval)
        {
            var comparer = new RoundedDateTimeComparer(interval);
            return comparer.Equals(x, y);
        }
        public static bool EqualsRounded(this DateTime? x, DateTime? y)
        {
            return x.EqualsRounded(y, TimeSpan.FromSeconds(1));
        }
        public static bool EqualsRounded(this DateTime? x, DateTime? y, TimeSpan interval)
        {
            var comparer = new RoundedDateTimeComparer(interval);
            return comparer.Equals(x, y);
        }
        public static int CompareRounded(this DateTime x, DateTime y)
        {
            return x.CompareRounded(y, TimeSpan.FromSeconds(1));
        }
        public static int CompareRounded(this DateTime x, DateTime y, TimeSpan interval)
        {
            var comparer = new RoundedDateTimeComparer(interval);
            return comparer.Compare(x, y);
        }
        public static int CompareRounded(this DateTime? x, DateTime? y)
        {
            return x.CompareRounded(y, TimeSpan.FromSeconds(1));
        }
        public static int CompareRounded(this DateTime? x, DateTime? y, TimeSpan interval)
        {
            var comparer = new RoundedDateTimeComparer(interval);
            return comparer.Compare(x, y);
        }
    }
    public class RoundedDateTimeComparer : 
        IComparer<DateTime>, IComparer<DateTime?>,
        IEqualityComparer<DateTime>, IEqualityComparer<DateTime?>
    {
        private readonly TimeSpan _interval;
        public RoundedDateTimeComparer(TimeSpan interval)
        {
            _interval = interval;
        }
        public int Compare(DateTime x, DateTime y)
        {
            var roundedX = x.RoundToNearestInterval(_interval);
            var roundedY = y.RoundToNearestInterval(_interval);
            return roundedX.CompareTo(roundedY);
        }
        public int Compare(DateTime? x, DateTime? y)
        {
            return x.HasValue && y.HasValue ? Compare(x.Value, y.Value) : (y.HasValue ? 1 : -1);
        }
        public bool Equals(DateTime x, DateTime y)
        {
            var roundedX = x.RoundToNearestInterval(_interval);
            var roundedY = y.RoundToNearestInterval(_interval);
            return roundedX.Equals(roundedY);
        }
        public bool Equals(DateTime? x, DateTime? y)
        {
            return x.HasValue && y.HasValue ? Equals(x.Value, y.Value) : x.Equals(y);
        }
        public int GetHashCode(DateTime obj)
        {
            var rounded = obj.RoundToNearestInterval(_interval);
            return rounded.GetHashCode();
        }
        public int GetHashCode(DateTime? obj)
        {
            return obj.HasValue ? GetHashCode(obj.Value) : 0;
        }
    }
