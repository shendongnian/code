    var latestFile = files.OrderByDescending(ParseFileDateTime)
                          .FirstOrDefault();
    ...
    private const string FileDateTimePattern = "yyyy'.'
    public static DateTime ParseFileDateTime(string name)
    {
        if (name.Length < 19)
        {
            throw new ArgumentException("No date/time in filename: " + name);
        }
        string text = name.Substring(name.Length - 19);
        return DateTime.ParseExact(text,
                                   "yyyy'.'MM'.'dd'_'HH'-'mm'-'ss",
                                   CultureInfo.InvariantCulture);
    }
