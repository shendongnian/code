    Dictionary<string, List<string>> cache;
    ...
    List<string> subCat;
    if cache.TryGetValue (selVal, out subCat) 
    {
        // no need to call database
    }
    else
    {
       // else call database
       // insert result in cache
    }
