    public class PageableQuery<T> : IPageableQuery<T>
    {
        readonly IQueryable<T> _sourceQuery;
        readonly Lazy<int> _totalItemCount; 
        public int TotalPages { get { return (int)Math.Ceiling((double)TotalItemCount / PageSize); } }
        public int TotalItemCount { get { return _totalItemCount.Value; } }
        public int PageSize { get; private set; }
        public PageableQuery(IQueryable<T> sourceQuery, int pageSize)
        {
            _sourceQuery = sourceQuery;
            _totalItemCount = new Lazy<int>(() => _sourceQuery.Count());
            PageSize = pageSize;
        }
        public IEnumerator<T> GetEnumerator() { return _sourceQuery.GetEnumerator();}
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public Expression Expression { get { return _sourceQuery.Expression; } }
        public Type ElementType { get { return _sourceQuery.ElementType; } }
        public IQueryProvider Provider { get { return _sourceQuery.Provider; } }
    }
    public class OrderedPageableQuery<T> : IOrderedPageableQuery<T>
    {
        readonly IPageableQuery<T> _sourcePageableQuery;
        readonly IOrderedQueryable<T> _sourceQuery;
        public int TotalPages { get { return (int)Math.Ceiling((double)TotalItemCount / PageSize); } }
        public int TotalItemCount { get { return _sourcePageableQuery.TotalItemCount; } }
        public int PageSize { get { return _sourcePageableQuery.PageSize; } }
        public OrderedPageableQuery(IPageableQuery<T> sourcePageableQuery, IOrderedQueryable<T> newSourceQuery)
        {
            _sourcePageableQuery = sourcePageableQuery;
            _sourceQuery = newSourceQuery;
        }
        public IEnumerator<T> GetEnumerator() { return _sourceQuery.GetEnumerator();}
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public Expression Expression { get { return _sourceQuery.Expression; } }
        public Type ElementType { get { return _sourceQuery.ElementType; } }
        public IQueryProvider Provider { get { return _sourceQuery.Provider; } }
    }
