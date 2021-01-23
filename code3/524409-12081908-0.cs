    public static bool IsNumeric(string text)
    {
        return string.IsNullOrEmpty(text) ? false :
                Regex.IsMatch(text, @"^\s*\-?\d+(\.\d+)?\s*$");
    }
