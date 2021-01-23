    public ContentService(ICacheHandler cacheHandler = null)
    {
        // Suppose I have a field of type ICacheHandler to store the handler
        _cacheHandler = cacheHandler ?? new CacheHandler(...);
    }
