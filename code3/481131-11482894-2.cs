    public class MemcachedCache : ICache
    {
            private MemcachedClient cache;
    
            private TimeSpan _timeSpan = new TimeSpan(
                Settings.Default.DefaultCacheDuration_Days,
                Settings.Default.DefaultCacheDuration_Hours,
                Settings.Default.DefaultCacheDuration_Minutes, 0);
    
            public MemcachedCache()
            {
                cache = new MemcachedClient();
            }
            /// <summary>
            /// Gets a cache object based on the cache_key.
            /// </summary>
            /// <param name="cache_key"></param>
            /// <returns></returns>
            public object Get(string cache_key)
            {
                return cache.Get(cache_key);
            }
            /// <summary>
            /// Override to allow expiration at a specific date/time and a priority level.
            /// </summary>
            /// <param name="cache_key"></param>
            /// <param name="cache_object"></param>
            /// <param name="expiration"></param>
            /// <param name="priority"></param>
            public void Set(string cache_key, object cache_object, DateTime expiration, CacheItemPriority priority)
            {
                cache.Store(StoreMode.Set, cache_key, cache_object, expiration);
            }
    
            /// <summary>
            /// Override to cache for a specified amount of time and a priority level.
            /// </summary>
            /// <param name="cache_key"></param>
            /// <param name="cache_object"></param>
            /// <param name="expiration"></param>
            /// <param name="priority"></param>
            public void Set(string cache_key, object cache_object, TimeSpan expiration, CacheItemPriority priority)
            {
                cache.Store(StoreMode.Set, cache_key, cache_object, expiration);
            }
    }
