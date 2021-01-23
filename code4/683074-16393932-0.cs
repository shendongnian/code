    public bool ValidateTime(string time)
    {
        DateTime ignored;
        return DateTime.TryParseExact(time, "HH:mm:ss",
                                      CultureInfo.InvariantCulture, 
                                      DateTimeStyles.None,
                                      out ignored);
    }
