    // June 6, 2013 2:00 PM  Kind = Unspecified
    DateTime dt = new DateTime(2013, 6, 13, 14, 0, 0);
    // This is the correct Windows time zone for New York
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    // Get the time in UTC - The kind matters here.
    DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dt, tz);
    // Feed it to a quartz event trigger
    trigger.StartTimeUtc = utc;
