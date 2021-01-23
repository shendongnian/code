      Console.WriteLine("Local time zone is '{0}'.", TimeZoneInfo.Local.Id);
      var gmTime          = new DateTime(2013, 03, 02, 01, 00, 00, DateTimeKind.Utc);
      var localTime       = new DateTime(2013, 03, 02, 01, 00, 00, DateTimeKind.Local);
      var unspecifiedTime = new DateTime(2013, 03, 02, 01, 00, 00);
      var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
      var gmTimeConverted           = TimeZoneInfo.ConvertTime(gmTime,          timeZone); // 03/02/2013 8:00:00AM
      var localTimeConverted        = TimeZoneInfo.ConvertTime(localTime,       timeZone); // 03/02/2013 
      var unspecifiedTimeConverted  = TimeZoneInfo.ConvertTime(unspecifiedTime, timeZone);
      Console.WriteLine("Converting GMT         to EST: {0}", gmTimeConverted);
      Console.WriteLine("Converting Local       to EST: {0}", localTimeConverted);
      Console.WriteLine("Converting Unspecified to EST: {0}", unspecifiedTimeConverted);
