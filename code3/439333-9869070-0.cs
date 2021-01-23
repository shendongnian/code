    private static bool ContainsKey(NameValueCollection collection, string key)
    {
        if (collection.Get(key) == null)
        {
            return collection.AllKeys.Contains(key);
        }
    
        return true;
    }
