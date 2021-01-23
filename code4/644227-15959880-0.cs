    NodaTime.ZonedDateTime hereAndNow = NodaTime.SystemClock.Instance.Now.InZone(
        NodaTime.DateTimeZoneProviders.Tzdb.GetSystemDefault());
    System.TimeSpan zoneOffset = hereAndNow.ToDateTimeOffset().Offset;
    string sTimeDisplay = string.Format("{0:G} {1} (UTC{2}{3:hh\\:mm} {4})", 
        hereAndNow.ToDateTimeOffset(), 
        hereAndNow.Zone.GetZoneInterval(hereAndNow.ToInstant()).Name, 
        zoneOffset < TimeSpan.Zero ? "-" : "+", 
        zoneOffset, 
        hereAndNow.Zone.Id);
