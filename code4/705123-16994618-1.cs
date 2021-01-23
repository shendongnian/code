    // Central Standard Time
    var dto = new DateTimeOffset(2013, 11, 3, 1, 0, 0, TimeSpan.FromHours(-6));
    var utc = dto.ToUniversalTime();
    Debug.WriteLine(utc); // 11/3/2013 7:00:00 AM +00:00
    // Central Daylight Time
    var dto = new DateTimeOffset(2013, 11, 3, 1, 0, 0, TimeSpan.FromHours(-5));
    var utc = dto.ToUniversalTime();
    Debug.WriteLine(utc); // 11/3/2013 6:00:00 AM +00:00
