    // This will return the Windows zone that matches the IANA zone, if one exists.
    public string IanaToWindows(string ianaZoneId)
    {
        var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
        var mappings = tzdbSource.WindowsMapping.MapZones;
        var item = mappings.FirstOrDefault(x => x.TzdbIds.Contains(ianaZoneId));
        if (item == null) return null;
        return item.WindowsId;
    }
    // This will return the "primary" IANA zone that matches the given windows zone.
    // If the primary zone is a link, it then resolves it to the canonical ID.
    public string WindowsToIana(string windowsZoneId)
    {
        var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
        var tzi = TimeZoneInfo.FindSystemTimeZoneById(windowsZoneId);
        var tzid = tzdbSource.MapTimeZoneId(tzi);
        return tzdbSource.CanonicalIdMap[tzid];
    }
