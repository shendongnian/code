    public class CacheManager : ICacheManager
    {
         private ObjectCache Cache
         {
              get
              {
                   return MemoryCache.Default;
              }
         }
    
         public T Get<T>(string key)
         {
              return (T)Cache[key];
         }
    
         public void Set(string key, object data, int cacheTime)
         {
              if (data == null)
              {
                   return;
              }
    
              CacheItemPolicy policy = new CacheItemPolicy();
              policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
    
              Cache.Add(new CacheItem(key, data), policy);
         }
    
         public bool IsSet(string key)
         {
              return (Cache.Contains(key));
         }
    
         public void Remove(string key)
         {
              Cache.Remove(key);
         }
    
         public void Clear()
         {
              foreach (var item in Cache)
              {
                   Remove(item.Key);
              }
         }
    }
