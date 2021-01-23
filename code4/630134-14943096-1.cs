    string TrimToDigits(string text)
    {
        var pattern = @"\d.*\d";
        var regex = new Regex(pattern);
        Match m = regex.Match(text);   // m is the first match
        if (m.Success)
        {
            return m.Value;
        }
        return String.Empty;
    }
