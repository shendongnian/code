    private long ConvertToTimestamp(DateTime value)
    {
        TimeZoneInfo NYTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime NyTime = TimeZoneInfo.ConvertTime(value, NYTimeZone);
        TimeZone localZone = TimeZone.CurrentTimeZone;
        System.Globalization.DaylightTime dst = localZone.GetDaylightChanges(NyTime.Year);
        NyTime = NyTime.AddHours(-1);
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
        TimeSpan span = (NyTime - epoch);
        return (long)Convert.ToDouble(span.TotalSeconds);
    }
