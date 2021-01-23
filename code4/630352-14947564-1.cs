    /// <summary>
    /// Summary description for ResourceFactory
    /// </summary>
    public static class ResourceFactory
    {
        private const string _cacheKeyFormat = "AppResource[{0}]";
        private static readonly ObjectCache _cache = MemoryCache.Default;
        private static readonly CacheItemPolicy _policy = new CacheItemPolicy() 
        { 
            SlidingExpiration = TimeSpan.FromMinutes(Int32.Parse(ConfigurationManager.AppSettings["AppResourceTimeout"] ?? "20")), 
            RemovedCallback = new CacheEntryRemovedCallback(AppResourceRemovedCallback) 
        };
        private static void AppResourceRemovedCallback(CacheEntryRemovedArguments args)
        {
            // item was removed from cache
        }
        #region Extensions to make ObjectCache work with Lazy
        public static TValue GetOrAdd<TKey, TValue>(this ObjectCache @this, TKey key, Func<TKey, TValue> valueFactory, CacheItemPolicy policy)
        {
            Lazy<TValue> lazy = new Lazy<TValue>(() => valueFactory(key), true);
            return ((Lazy<TValue>)@this.AddOrGetExisting(key.ToString(), lazy, policy) ?? lazy).Value;
        }
        public static TValue GetOrAdd<TKey, TParam1, TValue>(this ObjectCache @this, TKey key, TParam1 param1, Func<TKey, TParam1, TValue> valueFactory, CacheItemPolicy policy)
        {
            Lazy<TValue> lazy = new Lazy<TValue>(() => valueFactory(key, param1), true);
            return ((Lazy<TValue>)@this.AddOrGetExisting(key.ToString(), lazy, policy) ?? lazy).Value;
        }
        #endregion
        public static AppResourceEntity GetResourceById(int resourceId)
        {
            #region sanity checks
            if (resourceId < 0) throw new ArgumentException("Invalid parameter", "resourceId");
            #endregion
            string key = string.Format(_cacheKeyFormat, resourceId);
            AppResourceEntity resource = _cache.GetOrAdd(
                key, 
                resourceId, 
                (k, r) =>
                {
                    return AppResourceDataLayer.GetResourceById(r);
                }, 
                _policy
            );
            return resource;
        }
    }
