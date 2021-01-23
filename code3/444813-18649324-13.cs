    string tzid1 = "W. Australia Standard Time"; // Perth
    TimeZoneInfo tz1 = TimeZoneInfo.FindSystemTimeZoneById(tzid1);
    string tzid2 = "Sri Lanka Standard Time"; // Sri Jeyawardenepura
    TimeZoneInfo tz2 = TimeZoneInfo.FindSystemTimeZoneById(tzid2);
    DateTime dt = new DateTime(2006, 1, 1, 2, 0, 0);
    DateTimeOffset dto1 = new DateTimeOffset(dt, tz1.GetUtcOffset(dt));
    Debug.WriteLine(dto1);  // 1/1/2006 2:00:00 AM +08:00
    DateTimeOffset dto2 = TimeZoneInfo.ConvertTime(dto1, tz2);
    Debug.WriteLine(dto2);  // 12/31/2005 11:30:00 PM +05:30
    DateTimeOffset dto3 = TimeZoneInfo.ConvertTime(dto2, tz1);
    Debug.WriteLine(dto3);  // 1/1/2006 3:00:00 AM +09:00
