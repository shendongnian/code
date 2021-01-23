    foreach(var kv in dictionary2)
    {
        List<int> values;
        if (dictionary1.TryGetValue(kv.Key, out values))
        {
            dictionary1[kv.Key].Union(values).ToList();
        }
        else
        {
            dictionary1.Add(kv.Key, kv.Value);
        }
    } 
