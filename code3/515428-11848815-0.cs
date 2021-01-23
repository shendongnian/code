     using System.Runtime.Caching;
          
        public class RegularCacheProvider : ICacheProvider
            {
                private ObjectCache Cache { get { return MemoryCache.Default; } }
        
                object ICacheProvider.Get(string key)
                {
                    return Cache[key];
                }
        
                void ICacheProvider.Set(string key, object data, int cacheTime = 30)
                {
                    var policy = new CacheItemPolicy {AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)};
                    Cache.Add(new CacheItem(key, data), policy);
                }
        
                void ICacheProvider.Unset(string key)
                {
                    Cache.Remove(key);
                }
            }
