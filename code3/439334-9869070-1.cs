    private static bool ContainsKey(this NameValueCollection collection, string key)
    {
        if (collection.Get(key) == null)
        {
            return collection.AllKeys.Contains(key);
        }
    
        return true;
    }
