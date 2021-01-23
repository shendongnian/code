    foreach(var kvp in dictFinal)
    {
        List<string> listInDict1;
        if(dict.TryGetValue(kvp.Key, out listInDict1))
        {
            dictFinal[kvp.Key] = kvp.Value.Union(listInDict1).ToList();
            dict.Remove(kvp.Key);
        }
    }
    // now add all that is in dict but not in dictFinal
    foreach(var kvp in dict)
        dictFinal.Add(kvp.Key, kvp.Value);
