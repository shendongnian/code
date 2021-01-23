    public static DateTime? CIMToUTCDateTime(string CIM_DATETIME)
    {
        // CIM_DATETIME must be 25 characters in length
        if (string.IsNullOrEmpty(CIM_DATETIME) || CIM_DATETIME.Length != 25)
            return null;
        // Get the datetime portion of the string without timezone offset
        string dtPortion = CIM_DATETIME.Substring(0, 21);
        // convert to datetime
        DateTime dt;
        if (!DateTime.TryParseExact(dtPortion, "yyyyMMddHHmmss.ffffff", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal, out dt))
            return null;
        // subtract timezone offset to get UTC time equivalent
        int tzoffset;
        if (!Int32.TryParse(CIM_DATETIME.Substring(21), out tzoffset))
            return null;
        dt = dt.AddMinutes(-tzoffset);
        // return UTC datetime
        return dt;
    }
