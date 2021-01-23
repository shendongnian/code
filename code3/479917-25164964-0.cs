    static readonly Regex QueryStringRegex1 = new Regex(@"\?[^#]*");
    static readonly Regex QueryStringRegex2 = new Regex(@"(?<name>[^?&=]+)=(?<value>[^&=]*)");
    public static Dictionary<string, string> QueryDictionary(this Uri uri)
    {
        return QueryStringRegex1
            .Matches(uri.OriginalString)// between ? and #
            .Cast<Match>()
            .Select(x => QueryStringRegex2
                .Matches(x.Value)// between ? and &
                .Cast<Match>()
                .Select(y => y.Groups)
                .ToDictionary(y => y["name"].Value, y => y["value"].Value))
            .FirstOrDefault();
    }
