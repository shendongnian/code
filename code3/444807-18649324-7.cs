    string tzid1 = "Australia/Perth";
    DateTimeZone tz1 = DateTimeZoneProviders.Tzdb[tzid1];
    string tzid2 = "Asia/Colombo"; // Sri Jeyawardenepura
    DateTimeZone tz2 = DateTimeZoneProviders.Tzdb[tzid2];
    LocalDateTime ldt1 = new LocalDateTime(2006, 1, 1, 2, 0, 0);
    ZonedDateTime zdt1 = ldt1.InZoneStrictly(tz1);
    Debug.WriteLine(zdt1.ToDateTimeOffset()); // 1/1/2006 2:00:00 AM +08:00
    ZonedDateTime zdt2 = zdt1.WithZone(tz2);
    Debug.WriteLine(zdt2.ToDateTimeOffset()); // 1/1/2006 12:00:00 AM +06:00
    ZonedDateTime zdt3 = zdt1.WithZone(tz1);
    Debug.WriteLine(zdt3.ToDateTimeOffset()); // 1/1/2006 2:00:00 AM +08:00
