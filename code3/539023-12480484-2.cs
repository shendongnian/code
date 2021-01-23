    var dictionary = new Dictionary<string, CacheItem<T>>(Global.Keys.Count);
    foreach (var k in Globals.Keys)                       
    {                           
        dictionary.Add(k, new CacheItem<T>());
    }
    _Cache = dictionary;
