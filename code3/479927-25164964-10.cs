    static readonly char[] QueryStringSeparator1 = "#".ToCharArray();
    static readonly char[] QueryStringSeparator2 = "?".ToCharArray();
    static readonly char[] QueryStringSeparator3 = "&".ToCharArray();
    static readonly char[] QueryStringSeparator4 = "=".ToCharArray();
    public static Dictionary<string, string> QueryDictionary(this Uri uri)
    {
        return uri.ToString()
            .Split(QueryStringSeparator1, StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a.Split(QueryStringSeparator2, StringSplitOptions.RemoveEmptyEntries)
                .Select(b => b.Split(QueryStringSeparator3, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Split(QueryStringSeparator4))
                    .Where(c => c[0].Length > 0)
                    .ToDictionary(c => Uri.UnescapeDataString(c[0]), c => c.Length > 1 ? Uri.UnescapeDataString(c[1]) : ""))
                .ElementAtOrDefault(1))// after ?
            .FirstOrDefault()// before #
            ?? new Dictionary<string, string>();
    }
