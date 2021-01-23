    public static IEnumerable<string[]> Get(string csvFile)
    {
        return csvFile
            .ReadAsStream()
            .SplitCrLf()
            .Where(row => !string.IsNullOrWhiteSpace(row))
            .Select(row => row.Split(','));
    }
