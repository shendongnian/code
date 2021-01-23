    public static class TimeExtensions
    {
        public static bool IsBetween(this DateTime time, DateTime startTime, DateTime endTime)
        {
            return (time.TimeOfDay >= startTime.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay);
        }
    }
