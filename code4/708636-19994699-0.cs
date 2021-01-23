    public static string ToSentenceCase(this string value)
    {
        string[] spacedWords
            = ((IEnumerable<char>)value).Skip(1)
            .Select(c => c == char.ToUpper(c)
                ? " " + char.ToLower(c).ToString() 
                : c.ToString()).ToArray();
    
        string result = value.Substring(0, 1)
            + (String.Join("", spacedWords)).Trim();
    
        return result;
    }
