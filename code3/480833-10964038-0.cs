     public static Dictionary<string, object> CacheItems
        {
            get
            {
                lock (locker)
                {
                    return cacheItems;
                }
            }
    
            set
            {
                lock (locker)
                {
                    cacheItems = value;
                }
            }
        }
