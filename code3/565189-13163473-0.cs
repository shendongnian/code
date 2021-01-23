    Console.WriteLine(CultureInfo.InstalledUICulture.DisplayName);
    var tzi = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
    Console.WriteLine(tzi.Id);              // always English
    Console.WriteLine(tzi.DisplayName);     // localized
    Console.WriteLine(tzi.StandardName);    // localized
    Console.WriteLine(tzi.DaylightName);    // localized
