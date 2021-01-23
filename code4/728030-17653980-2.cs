    public static class CacheExtensions
    {
         public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
         {
              return Get(cacheManager, key, 60, acquire);
         }
    
         public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
         {
              if (cacheManager.IsSet(key))
              {
                   return cacheManager.Get<T>(key);
              }
              else
              {
                   var result = acquire();
    
                   cacheManager.Set(key, result, cacheTime);
    
                   return result;
              }
         }
    }
