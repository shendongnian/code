    public static class TimeExtensions
    {
        public static bool IsBetween(this DateTime time, DateTime startTime, DateTime endTime)
        {
            if (startTime.TimeOfDay < endTime.TimeOfDay)
                return (time.TimeOfDay >= startTime.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay);
            else
                return !(time.TimeOfDay >= startTime.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay);
        }
    }
