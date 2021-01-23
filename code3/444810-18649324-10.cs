    string tzid1 = "W. Australia Standard Time"; // Perth
    DateTimeZone tz1 = DateTimeZoneProviders.Bcl[tzid1];
    string tzid2 = "Sri Lanka Standard Time"; // Sri Jeyawardenepura
    DateTimeZone tz2 = DateTimeZoneProviders.Bcl[tzid2];
    LocalDateTime ldt1 = new LocalDateTime(2006, 1, 1, 2, 0, 0);
    ZonedDateTime zdt1 = ldt1.InZoneStrictly(tz1);
    Debug.WriteLine(zdt1.ToDateTimeOffset()); // 1/1/2006 2:00:00 AM +08:00
    ZonedDateTime zdt2 = zdt1.WithZone(tz2);
    Debug.WriteLine(zdt2.ToDateTimeOffset()); // 12/31/2005 11:30:00 PM +05:30
    ZonedDateTime zdt3 = zdt1.WithZone(tz1);
    Debug.WriteLine(zdt3.ToDateTimeOffset()); // 1/1/2006 2:00:00 AM +08:00
