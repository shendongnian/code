    // Since your input value is in UTC, parse it directly as an Instant.
    var pattern = InstantPattern.CreateWithInvariantCulture("ddMMyyHHmmss");
    var parseResult = pattern.Parse("150713192900");
    if (!parseResult.Success)
        throw new InvalidDataException("...whatever...");
    var instant = parseResult.Value;
    Debug.WriteLine(instant);  // 2013-07-15T19:29:00Z
    // You will always be better off with the tzdb, but either of these will work.
    var timeZone = DateTimeZoneProviders.Tzdb["Pacific/Auckland"];
    //var timeZone = DateTimeZoneProviders.Bcl["New Zealand Standard Time"];
    // Convert the instant to the zone's local time
    var zonedDateTime = instant.InZone(timeZone);
    Debug.WriteLine(zonedDateTime);
      // Local: 7/16/2013 7:29:00 AM Offset: +12 Zone: Pacific/Auckland
    // and if you must have a DateTime, get it like this
    var bclDateTime = zonedDateTime.ToDateTimeUnspecified();
    Debug.WriteLine(bclDateTime.ToString("o"));  // 2013-07-16T07:29:00.0000000
