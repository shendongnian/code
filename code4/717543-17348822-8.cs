    string tz = TZConvert.IanaToWindows("America/Los_Angeles");
    // Result:  "Eastern Standard Time"
    string tz = TZConvert.WindowsToIana("Eastern Standard Time");
    // result:  "America/New_York"
    string tz = TZConvert.WindowsToIana("Eastern Standard Time", "CA");
    // result:  "America/Toronto"
