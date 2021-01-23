    public static string AsStringConcat(this IEnumerable<char> characters)
    {        
        return String.Concat(characters);
    }
    public static string AsStringNew(this IEnumerable<char> characters)
    {
        return new String(characters.ToArray());
    }
    public static string AsStringSb(this IEnumerable<char> characters)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in characters)
        {
            sb.Append(c);
        }
        return sb.ToString();
    }
