    public static IEnumerable<T> Get<T>(string csvFile, Func<string[], T> factory)
    {
        return csvFile
            .ReadAsStream()
            .SplitCrLf()
            .Where(row => !string.IsNullOrWhiteSpace(row))
            .Select(row => factory(row.Split(',')));
    }
