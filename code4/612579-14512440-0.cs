    var zoneProvider = DateTimeZoneProviders.Tzdb;
    var sourceZone = zoneProvider.GetZoneOrNull("Europe/Brussels");
    var targetZone = zoneProvider.GetZoneOrNull("Australia/Melbourne");
    if (sourceZone == null || targetZone == null)
    {
        Console.WriteLine("Time zone not found");
        return;
    }
    var dateParseResult = LocalDatePattern.IsoPattern.Parse(date);
    int hourValue, minuteValue;
    if (!dateParseResult.Success ||
        !int.TryParse(hour, out hourValue) ||
        !int.TryParse(minute, out minuteValue))
    {
        Console.WriteLine("Parsing failed");
        return;       
    }
    var localDateTime = dateParseResult.Value + new LocalTime(hour, minute);
    var zonedDateTime = localDateTime.InZoneStrictly(sourceZone);
    Console.WriteLine(zonedDateTime.ToInstant());
    Console.WriteLine(zonedDateTime);
    Console.WriteLine(zonedDateTime.WithZone(targetZone));
