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
    public string WindowsToIana(string windowsZoneId)
    {
        var tzdbSource = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default;
        var tzi = TimeZoneInfo.FindSystemTimeZoneById(windowsZoneId);
        return tzdbSource.MapTimeZoneId(tzi);
    }
