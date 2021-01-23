    private static bool NowInTimeRange(string startTimeString, string endTimeString, string timeZoneId)
    {
        // convert to timespan
        var startTime = TimeSpan.Parse(startTimeString);
        var endTime = TimeSpan.Parse(endTimeString);
        // what time is it in the timezone specified?
        var now = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timeZoneId);
            
        // if they are in order, are we between the times specified?
        if (startTime <= endTime)
            return now.TimeOfDay >= startTime && now.TimeOfDay <= endTime;
        // when not in order, just see if either one of them matches.
        return now.TimeOfDay >= startTime || now.TimeOfDay <= endTime;
    }
