    string timestampString = "Saturday, April 20, 2013 9:00:00 PM";
    DateTime timestamp;
    bool isDateTime = DateTime.TryParseExact(timestampString, "U", null,
        DateTimeStyles.AdjustToUniversal, out timestamp);
    Console.WriteLine(isDateTime);     // True
    Console.WriteLine(timestamp);      // 4/20/2013 9:00:00 PM
    Console.WriteLine(timestamp.Kind); // Utc
