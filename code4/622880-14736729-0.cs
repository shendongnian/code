    public DateTime ParseAsUtc(string logDate, string timezoneName)
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timezoneName);
        var localDate = DateTime.Parse(logDate);
        var offset = new DateTimeOffset(localDate, timeZone.GetUtcOffset(localDate));
        return offset.ToUniversalTime().DateTime;
    }
    ParseAsUtc("2013-01-01 12:34:56", "Eastern Standard Time"); //01.01.2013 17:34:56
    ParseAsUtc("2013-07-01 12:34:56", "Eastern Standard Time"); //01.07.2013 16:34:56
    ParseAsUtc("2013-01-01 12:34:56", "China Standard Time");   //01.01.2013 04:34:56
    ParseAsUtc("2013-01-01 12:34:56", "China Standard Time");   //01.07.2013 04:34:56
