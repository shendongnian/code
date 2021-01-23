    private static DateTime? TryParseDateTime(string dateTime)
    {
        DateTime result;
        return DateTime.TryParseExact(dateTime,
                                      "yyyyMMddhhmmss",
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None,
                                      out result)
               ? result
               : null;
    }
