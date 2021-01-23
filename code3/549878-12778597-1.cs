    public void ClearApplicationCache()
    {
        List<string> keys = new List<string>();
        // retrieve application Cache enumerator
        IDictionaryEnumerator enumerator = Cache.GetEnumerator(); 
        // copy all keys that currently exist in Cache
        while (enumerator.MoveNext())
        {
            keys.Add(enumerator.Key.ToString());
        }
        // delete every key from cache
        for (int i = 0; i < keys.Count; i++)
        {
            Cache.Remove(keys[i]);
        }
    }
