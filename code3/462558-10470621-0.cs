    public static class DateExtensions
    {
        public static bool Between( this DateTime d, DateTime start, DateTime end )
        {
            return d >= start && d <= end;
        }
    }
