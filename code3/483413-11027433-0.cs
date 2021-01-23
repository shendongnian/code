    public static bool TryAddCacheItem(string key, object data)
    {
        locker.EnterWriteLock();
        try
        {
            if (cacheItems.ContainsKey(key))
            {
                return false;
            }
            cacheItems.Add(key, data);
            return true;
        }
        finally
        {
            locker.ExitWriteLock();
        }
    }
