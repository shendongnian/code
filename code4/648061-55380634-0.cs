           string DisplayName = "custom standard name here";//custom Standard Name to display eg: Kathmandu
           string StandardName = "custom standard name here"; // custom Standard Name eg: Asia/Kathamandu, Nepal
           string YourDate="27-03-2019 20:24:56"; // this DateTime doesn't contain any timeZone
           TimeSpan Offset = new TimeSpan(+5, 30, 00);// your TimeZone offset eg: timeZone of Nepal is +5:45
           TimeZoneInfo TimeZone = TimeZoneInfo.CreateCustomTimeZone(StandardName, Offset, DisplayName, StandardName);
           var RawDateTime = DateTime.SpecifyKind(DateTime.Parse(YourDate), DateTimeKind.Unspecified);// I all it RawDateTime Since it doesn't contain any TimeSpan
           DateTime UTCDateTime = TimeZoneInfo.ConvertTimeToUtc(RawDateTime, TimeZone);
           Console.WriteLine(UTCDateTime);
