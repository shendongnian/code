    static readonly Regex QueryStringRegex1 = new Regex(@"^[^#]*\?([^#]*)");
    static readonly Regex QueryStringRegex2 = new Regex(@"(?<name>[^&=]+)=(?<value>[^&=]*)");
    public static Dictionary<string, string> QueryDictionary(this Uri uri)
    {
        return QueryStringRegex1.Match(uri.ToString())// between ? and #
            .Groups
            .Cast<Group>()
            .Select(a => QueryStringRegex2.Matches(a.Value)// between ? and &
                .Cast<Match>()
                .Select(b => b.Groups)
                .ToDictionary(b => Uri.UnescapeDataString(b["name"].Value), b => Uri.UnescapeDataString(b["value"].Value)))
            .ElementAtOrDefault(1)
            ?? new Dictionary<string, string>();
    }
