    TimeZoneInfo nyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTime nyTime = GetLocalDateTime(DateTime.UtcNow, nyTimeZone);
    if (nyTimeZone.IsDaylightSavingTime(nyTime))
        nyTime = nyTime.AddHours(1);
    public static DateTime GetLocalDateTime(DateTime utcDateTime, TimeZoneInfo timeZone)
        {
            utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
            DateTime time = TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
            return time;
        }
