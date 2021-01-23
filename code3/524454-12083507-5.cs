    public static class TimeExtensions
    {
        public static TimeSpan To(this DateTimeOffset first, DateTimeOffset second)
        { 
            return first - second;
        }
        public static bool IsShorterThan(this TimeSpan timeSpan, TimeSpan amount)
        {
            return timeSpan > amount;
        }
        public static bool IsLongerThan(this TimeSpan timeSpan, TimeSpan amount)
        {
            return timeSpan < amount;
        }
    }
