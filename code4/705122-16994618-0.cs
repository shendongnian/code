    // Despite the name, this zone covers both CST and CDT.
    var tz = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
    var dt = new DateTime(2013, 11, 3, 1, 0, 0);
    var utc = TimeZoneInfo.ConvertTimeToUtc(dt, tz);
    Debug.WriteLine(utc); // 11/3/2013 7:00:00 AM
