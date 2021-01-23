    private static Regex _gtinRegex = new Regex("^(\\d{8}|\\d{12,14})$");
    public static bool IsValidGtin(string code)
    {
        if (!(_gtinRegex.IsMatch(code))) return false;
        code = code.PadLeft(14, '0');
        int sum = code.Select((c,i) => (c - '0')  * ((i % 2 == 0) ? 3 : 1)).Sum();
        return (sum % 10) == 0;
    }
