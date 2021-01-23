    object GetCachedValue(string id)
    {
        if (!Cache.ContainsKey(id))
        {
             lock (_staticObj)
             {
                if (!Cache.ContainsKey(id))
                {
                   //long running operation to fetch the value for id
                   object value = GetTheValueForId(id);
                   Cache.Add(id, value);
                }
             }
        }     
        return Cache[id];
    }
