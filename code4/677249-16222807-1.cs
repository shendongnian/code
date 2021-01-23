    public DateTime GetFirstDateFromString(string input)
    {
        DateTime d;
        Match match = Regex.Match(input, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}");
        // Exclude strings with no matching substring
        if (match.Success)
        {
            // Exclude matching substrings which aren't valid DateTimes
            if (DateTime.TryParseExact(match.Groups[1].Value, "dd.MM.yyyy", enUS, 
                           DateTimeStyles.None, out d))
            {
                return d;
            }
        }
        return null;
    }
 
