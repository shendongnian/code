    string tz = TZConvert.IanaToWindows("America/New_York");
    // Result:  "Eastern Standard Time"
    string tz = TZConvert.WindowsToIana("Eastern Standard Time");
    // result:  "America/New_York"
    string tz = TZConvert.WindowsToIana("Eastern Standard Time", "CA");
    // result:  "America/Toronto"
