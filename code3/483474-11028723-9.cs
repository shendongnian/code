    public static IEnumerable<KeyValuePair<string, object> CacheItems
    {
        get
        {
            return cacheItems.Select(x => x);
        }
    }
