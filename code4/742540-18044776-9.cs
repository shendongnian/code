    // on the client
    DateTime local = new DateTime(2013, 3, 10, 0, 0, 0, DateTimeKind.Local);
    DateTime utc = local.ToUniversalTime();
    string zoneId = TimeZoneInfo.Local.Id;
    // send both utc time and zone to the server
    // ...
    // on the server
    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
    DateTime theirTime = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
    DateTime newDate = theirTime.AddDays(1);
    Debug.WriteLine(newDate); //   3/11/2013 12:00:00 AM
