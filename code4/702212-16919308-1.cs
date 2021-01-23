    var latestFile = files.OrderByDescending(ParseFileDateTime)
                          .FirstOrDefault();
    ...
    public static DateTime ParseFileDateTime(string name)
    {
        int dateTimeStartIndex = name.Length - 19;
        if (dateTimeStartIndex < 0)
        {
            throw new ArgumentException("No date/time in filename: " + name);
        }
        string text = name.Substring(dateTimeStartIndex);
        return DateTime.ParseExact(text,
                                   "yyyy'.'MM'.'dd'_'HH'-'mm'-'ss",
                                   CultureInfo.InvariantCulture);
    }
