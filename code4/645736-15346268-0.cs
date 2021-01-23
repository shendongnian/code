    public static string ToLettersAndDigits(this string text)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
            if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                sb.Append(c);
        return sb.ToString().Trim();
    }
    public static string ToLetters(this string text)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
            if (char.IsLetter(c) || char.IsWhiteSpace(c))
                sb.Append(c);
        return sb.ToString().Trim();
    }
    
    public static string ToDigits(this string text)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
            if (char.IsDigit(c))
                sb.Append(c);
        return sb.ToString().Trim();
    }
