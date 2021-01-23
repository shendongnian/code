    public DateTime ParseOrdinalDateTime(string dt)
    {
        string[] expectedFormats = 
        DateTime d;
        if (DateTime.TryParseExact(dt, "dddd, d\"st\" MMMM yyyy", null, DateTimeStyles.None, out d))
            return d;
        if (DateTime.TryParseExact(dt, "dddd, d\"nd\" MMMM yyyy", null, DateTimeStyles.None, out d))
            return d;
        if (DateTime.TryParseExact(dt, "dddd, d\"rd\" MMMM yyyy", null, DateTimeStyles.None, out d))
            return d;
        if (DateTime.TryParseExact(dt, "dddd, d\"th\" MMMM yyyy", null, DateTimeStyles.None, out d))
            return d;
            
        throw new InvalidOperationException("Not a valid DateTime string");
    }
