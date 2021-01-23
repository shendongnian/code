    public static IEnumerable<string> BuildStrings(this IEnumerable<char> alphabet)
    {
        var strings = alphabet.Select(c => c.ToString());
        for (int i = 1; i < alphabet.Count(); i++)
        {
            strings = strings.Union(strings.SelectMany(s => alphabet.Select(c => s + c.ToString())));
        }
        return strings;
    }
