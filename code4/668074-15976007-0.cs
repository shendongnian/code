    static string EscapeChar(char c)
    {
        switch (c)
        {
            case '{':
                return "{{}";
            case '}':
                return "{}}";
            default:
                return c.ToString();
        }
    }
    public static string ConvertForSendKey(string password)
    {
        return String.Concat(password.Select(EscapeChar));
    }
