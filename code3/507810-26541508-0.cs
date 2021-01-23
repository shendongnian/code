    static string StringBuilderChars(IEnumerable<char> charSequence)
    {
        var sb = new StringBuilder();
        foreach (var c in charSequence)
        {
            sb.Append(c);
        }
        return sb.ToString();
    }
