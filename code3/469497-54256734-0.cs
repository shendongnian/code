    DateTime utcTime = DateTime.Parse("30.10.2018 18:21:34")
    DateTime localtime = ConvertUTCToLocalTime(utcTime);
    public static DateTime ConvertUTCToLocalTime(DateTime UTCTime)
    {
        var localZone = TimeZone.CurrentTimeZone;
        var offset = localZone.GetUtcOffset(UTCTime);
        var localTime = UTCTime.AddHours(offset.Hours);
        return localTime;
    }
