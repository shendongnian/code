    static DateTime? GetFirstDateFromString(string inputText)
    {
        var regex = new Regex(@"\b\d{2}\.\d{2}.\d{4}\b");
        foreach(Match m in regex.Matches(inputText))
        {
            DateTime dt;
            if (DateTime.TryParseExact(m.Value, "dd.MM.yyyy", null, DateTimeStyles.None, out dt))
                return dt;
        }
        return null;
    }
