    public DateTime? GetFirstDateFromString(string input)
    {
        DateTime d;
        // Exclude strings with no matching substring
        foreach (Match m in Regex.Matches(input, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}"))
        {
            // Exclude matching substrings which aren't valid DateTimes
            if (DateTime.TryParseExact(match.Value, "dd.MM.yyyy", null, 
                DateTimeStyles.None, out d))
            {
                return d;
            }
        }
        return null;
    }
 
