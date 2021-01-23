    static readonly char[] Delimiter0 = "#".ToCharArray();
    static readonly char[] Delimiter1 = "?".ToCharArray();
    static readonly char[] Delimiter2 = "&".ToCharArray();
    static readonly char[] Delimiter3 = "=".ToCharArray();
    public static Dictionary<string, string> QueryArguments(this Uri uri)
    {
        return uri
            .OriginalString
            .Split(Delimiter0, StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a.Split(Delimiter1, StringSplitOptions.RemoveEmptyEntries)
                .Select(b => b.Split(Delimiter2, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Split(Delimiter3))
                    .Where(c => c[0].Length > 0)
                    .ToDictionary(c => c[0], c => c.Length > 1 ? c[1] : ""))
                .ElementAtOrDefault(1))// after ?
            .FirstOrDefault();// before #
    }
