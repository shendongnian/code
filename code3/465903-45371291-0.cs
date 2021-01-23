    /// <summary>
    /// Creates a GetOrRefreshCache function with encapsulated MemoryCache.
    /// </summary>
    /// <typeparam name="T">The type of inbound objects to cache.</typeparam>
    /// <typeparam name="TResult">How the objects will be serialized to cache and returned.</typeparam>
    /// <param name="cacheName">The name of the cache.</param>
    /// <param name="valueFactory">The factory for storing values.</param>
    /// <param name="keyFactory">An optional factory to choose cache keys.</param>
    /// <returns>A function to get or refresh from cache.</returns>
    public static Func<T, TResult> GetOrRefreshCacheFactory<T, TResult>(string cacheName, Func<T, TResult> valueFactory, Func<T, string> keyFactory = null) {
        var getKey = keyFactory ?? (obj => obj.GetHashCode().ToString());
        var cache = new MemoryCache(cacheName);
        // Thread-safe lazy cache
        TResult getOrRefreshCache(T obj) {
            var key = getKey(obj);
            var newValue = new Lazy<TResult>(() => valueFactory(obj));
            var value = (Lazy<TResult>) cache.AddOrGetExisting(key, newValue, ObjectCache.InfiniteAbsoluteExpiration);
            return (value ?? newValue).Value;
        }
        return getOrRefreshCache;
    }
