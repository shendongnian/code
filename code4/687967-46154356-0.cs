    public void ClearCacheItems()
    {
       List<string> keys = new List<string>();
       IDictionaryEnumerator enumerator = Cache.GetEnumerator();
     
       while (enumerator.MoveNext())
         keys.Add(enumerator.Key.ToString());
     
       for (int i = 0; i < keys.Count; i++)
          Cache.Remove(keys[i]);
    } 
