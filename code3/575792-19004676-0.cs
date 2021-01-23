    /// <summary>
    /// Tries to parse PayPal formatted date and time and converts it to an UTC.
    /// </summary>
    public static bool TryParsePaypalDatetimeToUtc(this string paypalDatetime, out DateTime retValue)
    {
        DateTime paymentDate;
        // PayPal formats from docs
        string[] formats = new string[] { "HH:mm:ss dd MMM yyyy PDT", "HH:mm:ss dd MMM yyyy PST", 
                                          "HH:mm:ss dd MMM, yyyy PST", "HH:mm:ss dd MMM, yyyy PDT", 
                                          "HH:mm:ss MMM dd, yyyy PST", "HH:mm:ss MMM dd, yyyy PDT" };
        if (false == DateTime.TryParseExact(paypalDatetime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out paymentDate))
        {
            retValue = DateTime.MinValue;
            return false;
        }
        retValue = TimeZoneInfo.ConvertTimeToUtc(paymentDate, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
        return true;
    }
