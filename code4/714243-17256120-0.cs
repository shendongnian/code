    class QueryResultEventArgs : EventArgs
    {
        public IEnumerable<string> Results { get; private set; }
        public QueryResultEventArgs(IEnumerable<string> results)
        {
            Results = results;
        }
    }
    ...
    public delegate void CacheStoreDelegate(object sender, QueryResultEventArgs e);
    ...
    this.OnQuery(new QueryResultEventArgs(GetAnyMatch));
