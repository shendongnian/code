    public DateTimeOffset CreateDateWithTimezone(string dateStr, TimeZoneInfo tzi)
    {
      DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Parse(dateStr), TimeZoneInfo.Local, tzi);
      return new DateTimeOffset(dt, tzi.GetUtcOffset(dt));
    }
