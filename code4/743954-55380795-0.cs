       string DisplayName = "custom standard name here";
       string StandardName = "custom standard name here"; 
       string YourDate="2013/8/15 10:0:0"; 
       TimeSpan Offset = new TimeSpan(+10, 00, 00);
       TimeZoneInfo TimeZone = TimeZoneInfo.CreateCustomTimeZone(StandardName, Offset, DisplayName, StandardName);
       var RawDateTime = DateTime.SpecifyKind(DateTime.Parse(YourDate), DateTimeKind.Unspecified);
       DateTime UTCDateTime = TimeZoneInfo.ConvertTimeToUtc(RawDateTime, TimeZone);
       Console.WriteLine(UTCDateTime);
