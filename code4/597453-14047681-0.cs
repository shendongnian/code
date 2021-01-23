    public static void OnRemove(string key, 
       object cacheItem, 
       System.Web.Caching.CacheItemRemovedReason reason)
       {
          AppendLog("The cached value with key '" + key + 
                "' was removed from the cache.  Reason: " + 
                reason.ToString()); 
    }
