    // 02/23/2012 12:08 AM (instead of reading LastWriteTime)
    DateTime original = new DateTime(2012, 02, 23, 00, 08, 00);
    // instead of ToUniversalTime(), which would use my local time zone
    TimeZoneInfo pstzone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    DateTime utc = TimeZoneInfo.ConvertTimeToUtc(original, pstzone); 
    // instead of a plain ToString(), which would use my local culture
    CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
    String display = utc.ToString("MM/dd/yyyy hh:mm tt", us);
    // output: display = 02/23/2012 08:08 AM
