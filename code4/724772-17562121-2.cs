    public static string TrimNewLines(string text)
    {
        while (text.EndsWith(Environment.NewLine))
        {
            text = text.Substring(0, text.Length - Environment.NewLine.Length);
        }
        return text;
    }
    private static readonly char[] NewLineChars = Environment.NewLine.ToCharArray();
    
    public static string TrimNewLines(string text)
    {
        return text.TrimEnd(NewLineChars);
    }
