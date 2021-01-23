    public Dictionary<string, object> SearchList
    (
        List<Dictionary<string, object>> testData,
        Dictionary<string, object> searchPattern
    )
    {
        return testData.FirstOrDefault(x => searchPattern.All(x.Contains));
    }
