    public static int TryParseInline(string in) {
        int a;
        int.TryParse(sessionFromYear, out a);
        return a;
    }
    ...
    sample.AddRange(Statistics.Select(player => new Stats
    {
        SeasonFromYear = Util.TryParseInline(seasonFromYear),
        ...
    })
