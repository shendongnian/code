After thinking about it, in your example, you are updating it regardless, so AddOrGetExisting isn't the best, as you mentioned, you are setting it later anyway.  Below it a simple implementation that I **think** fits what you are asking for.  If I am wrong, please let me know!
    public class MemoryCacheWithEvents
    {
        private static MemoryCache _cache = new MemoryCache("myCache");
        private static object _syncLock = new object();
        public EventHandler<CacheChangeEventArgs> AddingCacheItem;
        public EventHandler<CacheChangeEventArgs> UpdatingCacheItem;
        public object GetAndSetExisting(string key, object value, CacheItemPolicy policy, string regionName = null)
        {
            lock (_syncLock)
            {
                var cacheItem = new CacheItem(key, value, regionName);
                var existing = _cache.GetCacheItem(key, null);
                if (existing == null)
                {
                    OnAddingCacheItem(new CacheChangeEventArgs(null, cacheItem));
                }
                else
                {
                    OnUpdatingCacheItem(new CacheChangeEventArgs(existing, cacheItem));   
                }
                _cache.Set(cacheItem, policy);
                return existing;
            }
        }
        public virtual void OnAddingCacheItem(CacheChangeEventArgs eventArgs){
            var handler = AddingCacheItem;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }
        public virtual void OnUpdatingCacheItem(CacheChangeEventArgs eventArgs){
            var handler = UpdatingCacheItem;
            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }
    }
    public class CacheChangeEventArgs : EventArgs
    {
        public object OldCacheItem { get; set; }
        public object NewCacheItem { get; set; }
        public CacheChangeEventArgs(object oldCacheItem, object newCacheItem)
        {
            this.OldCacheItem = oldCacheItem;
            this.NewCacheItem = newCacheItem;
        }
    }
