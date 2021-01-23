    // on the client
    var local = new LocalDateTime(2013, 3, 10, 0, 0, 0);
    var zone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
    var zdt = local.InZoneStrictly(zone);
    // send zdt to server
    // ...
    // on the server
    var newDate = zdt.LocalDateTime.PlusDays(1);
    Debug.WriteLine(newDate); // 3/11/2013 12:00:00 AM
