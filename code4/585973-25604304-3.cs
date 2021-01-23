    public static TimeSpan GetOffSetTime(string date)
        {
            DateTime d = Convert.ToDateTime(date);
            TimeZone zone = TimeZone.CurrentTimeZone;
            TimeSpan local = zone.GetUtcOffset(d);
            return local;
        }
