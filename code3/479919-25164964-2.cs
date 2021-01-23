    static readonly char[] QueryStringSeparator1 = "#".ToCharArray();
    static readonly char[] QueryStringSeparator2 = "?".ToCharArray();
    static readonly char[] QueryStringSeparator3 = "&".ToCharArray();
    static readonly char[] QueryStringSeparator4 = "=".ToCharArray();
    public static Dictionary<string, string> QueryArguments(this Uri uri)
    {
        return uri
            .OriginalString
            .Split(QueryStringSeparator1, StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a.Split(QueryStringSeparator2, StringSplitOptions.RemoveEmptyEntries)
                .Select(b => b.Split(QueryStringSeparator3, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Split(QueryStringSeparator4))
                    .Where(c => c[0].Length > 0)
                    .ToDictionary(x => Uri.UnescapeDataString(x[0]), x => x.Length > 1 ? Uri.UnescapeDataString(x[1]) : ""))
                .ElementAtOrDefault(1))// after ?
            .FirstOrDefault();// before #
    }
