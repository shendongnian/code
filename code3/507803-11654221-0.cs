ToArrayString:        00:00:03.1695463
Concat:               00:00:07.2518054
StringBuilderChars:   00:00:03.1335455
StringBuilderStrings: 00:00:06.4618266
    static readonly IEnumerable<char> seq = Enumerable.Repeat('a', 300);
    static string ToArrayString(IEnumerable<char> charSequence)
    {
        return new String(charSequence.ToArray());
    }
    static string Concat(IEnumerable<char> charSequence)
    {
        return String.Concat(charSequence);
    }
    static string StringBuilderChars(IEnumerable<char> charSequence)
    {
        var sb = new StringBuilder();
        foreach (var c in charSequence)
        {
            sb.Append(c);
        }
        return sb.ToString();
    }
    static string StringBuilderStrings(IEnumerable<char> charSequence)
    {
        var sb = new StringBuilder();
        foreach (var c in charSequence)
        {
            sb.Append(c.ToString());
        }
        return sb.ToString();
    }
