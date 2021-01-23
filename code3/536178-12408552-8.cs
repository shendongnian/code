    static ConcurrentDictionary<string, Lazy<CacheItem>> Cache = 
        new ConcurrentDictionary<string, Lazy<CacheItem>>(StringComparer.Ordinal);
    ...
    CacheItem item = Cache.GetOrAdd(key, 
                   new Lazy<CacheItem>(()=> ExpensiveLoad(key))
                 ).Value;
