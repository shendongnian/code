    DateTime utcTime = new DateTime(2013, 03, 25, 10, 20, 00);
    TimeZoneInfo usersTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTime usersLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, usersTimeZone);
    Console.WriteLine(utcTime.ToString("hh:mm:ss");
    Console.WriteLine(usersLocalTime.ToString("hh:mm:ss");
