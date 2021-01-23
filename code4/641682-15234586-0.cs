    public static string ConvertEnum(this string value)
    {
        string result = string.Empty;
        char[] letters = value.ToCharArray();
        foreach (char c in letters)
            if (c.ToString() != c.ToString().ToLower())
                result += " " + c;
            else
                result += c.ToString();
        return result;
    }
