    string tzid1 = "W. Australia Standard Time"; // Perth
    TimeZoneInfo tz1 = TimeZoneInfo.FindSystemTimeZoneById(tzid1);
    string tzid2 = "Sri Lanka Standard Time"; // Sri Jeyawardenepura
    TimeZoneInfo tz2 = TimeZoneInfo.FindSystemTimeZoneById(tzid2);
    DateTime dt1 = new DateTime(2006, 1, 1, 2, 0, 0);
    Debug.WriteLine(dt1); // 1/1/2006 2:00:00 AM
    DateTime dt2 = TimeZoneInfo.ConvertTime(dt1, tz1, tz2);
    Debug.WriteLine(dt2); // 12/31/2005 11:30:00 PM
    DateTime dt3 = TimeZoneInfo.ConvertTime(dt2, tz2, tz1);
    Debug.WriteLine(dt3); // 1/1/2006 3:00:00 AM
