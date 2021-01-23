    DateTime local1 = DateTime.Parse("2012-10-28T00:30:00.0000000Z");
    DateTime local2 = DateTime.Parse("2012-10-28T01:30:00.0000000Z");
    Console.WriteLine(local1 == local2); // True
    
    DateTime utc1 = TimeZoneInfo.ConvertTimeToUtc(local1);
    DateTime utc2 = TimeZoneInfo.ConvertTimeToUtc(local2);
    Console.WriteLine(utc1 == utc2); // False. Hmm.
