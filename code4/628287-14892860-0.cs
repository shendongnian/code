    public static class CacheHelper
    {
        private static ObjectCache _cache;
        private const Double ChacheExpirationInMinutes = 10;
        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="entity">item cached</param>
        /// <param name="key">Name of item</param>
        public static void Add<T>(T entity, string key) where T : class
        {
            if (_cache == null)
            {
                _cache = MemoryCache.Default;
            }
            if (_cache.Contains(key))
                _cache.Remove(key);
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(ChacheExpirationInMinutes);
            _cache.Set(key, entity, cacheItemPolicy);
        }
        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            if (_cache == null)
            {
                _cache = MemoryCache.Default;
                return;
            }
            _cache.Remove(key);
        }
        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            if (_cache == null)
            {
                _cache = MemoryCache.Default;
            }
            try
            {
                return (T)_cache.Get(key);
            }
            catch
            {
                return null;
            }
        }
    }
