    static string LocalTimeToUTC(string timeZone, string localDateTime)
    {
        var pattern = LocalDateTimePattern.CreateWithInvariantCulture("dd/MM/yyyy HH:mm:ss");
        LocalDateTime ldt = pattern.Parse(localDateTime).Value;
        ZonedDateTime zdt = ldt.InZoneLeniently(DateTimeZoneProviders.Tzdb[timeZone]);
        Instant instant = zdt.ToInstant();
        ZonedDateTime utc = instant.InUtc();
        string output = utc.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    
        return output;
    }
