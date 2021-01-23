    public sealed class RequestCache : ReadWriterLockSlim
    {
        private static RequestCache cache_;
        private Dictionary<string, object> cache_ = new Dictionary<string, object>(StringComparer.OrdinalNoCompare);
        private RequestCache() { }
       
        public static RequestCache Instance
        {
            get 
            {
                if(cache_ == null)
                    cache_ = new RequestCache();
                return cache_;
            }
        } // eo Instance
        public static void DestroyCache()
        {
             EnterWriteLock();
             try {
                 cache_ = null;
             }
             finally
             {
                  ExitWriteLock();
             }
        } // eo DestroyCache
        public T Get<T>(string key, T def = default(T))
        {
            T ret;
            EnterReadLock();
            try
            {
                ret = cache_.ContainsKey(key) ? (T)cache_[key] : def;
            }
            finally
            {
                ExitReadLock();
            }
            return ret;
        }
        public void Add<T>(string key, T val)
        {
             EnterWriteLock();
             try
             {
                 cache_[key] = val;
             }
             finally
             {
                 ExitWriteLock();
             }
        }
    } // eo class RequestCache
