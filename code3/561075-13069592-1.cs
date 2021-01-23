    public DateTime GetDateByTimeZoneId(DateTime dateTime, string timeZone)
    {
       if (dateTime == null)
       {
            return null;
       }
       dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
       return TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
    }
