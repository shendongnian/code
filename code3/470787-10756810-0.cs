    class CachingQuery<T> : IQueryable<T>
    {
        private readonly CachingQueryProvider _provider;
        private readonly Expression _expression;
        public CachingQuery(CachingQueryProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }
        // etc.
    }
    class CachingQueryProvider : IQueryProvider
    {
        private readonly IQueryProvider _original;
        public CachingQueryProvider(IQueryProvider original)
        {
            _original = original;
        }
        
        // etc.
    }
    public static class CachedQueryable
    {
        public static IQuerable<T> AsCached(this IQueryable<T> source)
        {
            return new CachingQuery<T>(
                 new CachingQueryProvider(source.Provider), 
                 source.Expression);
        }
    }
