    // on the client
    var local = new DateTime(2013, 3, 10, 0, 0, 0, DateTimeKind.Local);
    var utc = local.ToUniversalTime();
    var zoneId = TimeZoneInfo.Local.Id;
    // send both utc time and zone to the server
    // ...
    // on the server
    var tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
    var theirTime = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
    var newDate = theirTime.AddDays(1);
    Debug.WriteLine(newDate); //   3/11/2013 12:00:00 AM
