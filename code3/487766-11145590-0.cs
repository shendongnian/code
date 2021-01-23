    /// <summary>
    /// Caching provider
    /// </summary>
    public static class CacheProvider
    {
        const string CacheDependencyKey = "1FADE275-2C84-4a9b-B3E1-68ABB15E53C8";
        static readonly object SyncRoot = new object();
 
        /// <summary>
        /// Gets an item from cache. If the item does not exist, one will be
        /// created and added to the cache.
        /// </summary>
        /// <param name="key">Caching key</param>
        /// <param name="valueFactory">Function to create the item of it does not exist in the cache.</param>
        /// <param name="expiresAfter">Time after the item wille be removed from cache.</param>
        public static TValue GetOrAdd<TValue>(string key, Func<TValue> valueFactory, TimeSpan expiresAfter)
        {
            object itemFromCache = HttpRuntime.Cache.Get(key);
            if (itemFromCache == null)
            {
                lock (SyncRoot)
                {
                    itemFromCache = HttpRuntime.Cache.Get(key);
                    if (itemFromCache == null)
                    {
                        TValue value = valueFactory();
                        if (value != null)
                        {
                            if (HttpRuntime.Cache[CacheDependencyKey] == null)
                                HttpRuntime.Cache[CacheDependencyKey] = string.Empty;
 
                            HttpRuntime.Cache.Add(key, value, new CacheDependency(null, new string[] { CacheDependencyKey }), DateTime.Now.Add(expiresAfter), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                        }
                        return value;
                    }
                }
            }
            return (TValue)itemFromCache;
        }
 
        /// <summary>
        /// Invalidate all the items from the cache.
        /// </summary>
        public static void InvalidateCache()
        {
            HttpRuntime.Cache.Remove(CacheDependencyKey);
        }
    }
