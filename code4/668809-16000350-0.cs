    static DateTime? Search(List<string> lines)
    {
        if (lines.Count == 0)
        {
            return null;
        }
        DateTime parsedDate;
        // the first successful strategy will 'short circuit' the rest so they don't run
        if(TryGetDateStrategy1(lines, out parsedDate)
            || TryGetDateStrategy2(lines, out parsedDate)
            || etc. etc.) 
        {
            return parsedDate;
        }
        return null;
    }
    private static bool TryGetDateStrategy1(List<string> lines, out DateTime? date)
    {
        var dateField = lines.Last().Split(';')[19].Trim('\'').Trim();
        DateTime parsedDate;
        if (DateTime.TryParseExact(dateField, "MM'/'dd'/'yy HH:mm:ss", null, DateTimeStyles.AllowWhiteSpaces,out date))
        {
            date = parsedDate;
            return true;
        }
        return false;
    }
    private static bool  TryGetDateStrategy2(List<string> lines, out DateTime? date)
    {
        var dateField = lines.Last().Split(';')[18].Trim('\'').Trim();
        DateTime parsedDate;
        if (DateTime.TryParseExact(dateField, "MM'/'dd'/'yy HH:mm:ss", null, DateTimeStyles.AllowWhiteSpaces, out date))
        {
            date = parsedDate;
            return true;
        }
        return null;
    }
