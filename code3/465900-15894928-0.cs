    public T GetFromCache(string key, Func<T> valueFactory) 
    {
        var newValue = new Lazy<T>(valueFactory);
        // the line belows returns existing item or adds the new value if it doesn't exist
        var value = cache.AddOrGetExisting(key, newValue, MemoryCache.InfiniteExpiration);
        return (value ?? newValue).Value; // Lazy<T> handles the locking itself
    }
