    private string CacheKey { get; set; }
    protected CachedValueProviderBase(string cacheKey)
    {
        this.CacheKey = cacheKey + "_" + typeof(T).FullName;
    }
