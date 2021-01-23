    public Query In(string propertyName, IEnumerable<string> collection)
    {
        var query = new QueryParser(version, propertyName, analyzer).Parse(string.Join(" ", collection));
        return query;
    }
