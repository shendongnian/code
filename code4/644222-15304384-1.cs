    // starting with a .Net TimeZoneInfo
    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    // You need to resolve to a specific instant in time - a noda Instant
    // For illustrative purposes, I'll start from a regular .Net UTC DateTime
    var dateTime = DateTime.UtcNow;
    var instant = Instant.FromDateTimeUtc(dateTime);
    // note that if we really wanted to just get the current instant,
    // it's better and easier to use the following:
    // var instant = SystemClock.Instance.Now;
    // Now let's map the Windows time zone to an IANA/Olson time zone,
    // using the CLDR mappings embedded in NodaTime.  This will use
    // the *primary* mapping from the CLDR - that is, the ones marked
    // as "territory 001".
    // we need the NodaTime tzdb source.  In NodaTime 1.1 (beta):
    //var tzdbSource = TzdbDateTimeZoneSource.Default;
    // in NodaTime 1.0.1 (current stable):
    var tzdbSource = new TzdbDateTimeZoneSource("NodaTime.TimeZones.Tzdb");
    // map to the appropriate IANA/Olson tzid
    var tzid = tzdbSource.MapTimeZoneId(timeZoneInfo);
            
    // get a DateTimeZone from that id
    var dateTimeZone = DateTimeZoneProviders.Tzdb[tzid];
    // Finally, let's figure out what the abbreviation is
    // for the instant and zone we have.
    // now get a ZoneInterval for the zone and the instant
    var zoneInterval = dateTimeZone.GetZoneInterval(instant);
    // finally, you can get the correct time zone abbreviation
    var abbreviation = zoneInterval.Name;
    // abbreviation will be either PST or PDT depending
    // on what instant was provided
    Debug.WriteLine(abbreviation);
