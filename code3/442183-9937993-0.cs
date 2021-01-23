    TimeZoneInfo zone = TimeZoneInfo.Local;
    if (zone.SupportsDaylightSavingTime)
    {
        Console.WriteLine("System default zone uses DST...");
        Console.WriteLine("In DST? {0}", zone.IsDaylightSavingTime(DateTime.UtcNow);
    }
    else
    {
        Console.WriteLine("System default zone does not use DST.");
    }
