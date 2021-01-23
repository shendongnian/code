    private static SortedList<long, SearchResult> resultsList = new SortedList<long, SearchResult>();
    ...
        foreach (var v in resultsList.Values)
        {
    ...
    public static long RequestID = 0;
    protected void MakeRequest(string text)
    {
        SearchResult s = new SearchResult
        {
            SearchTerm = text,
            Count = 0
        };
        resultsList.Add(System.Threading.Interlocked.Increment(ref RequestID), s);
