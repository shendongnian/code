    List<string> cacheList = new List<string>();
    foreach (DictionaryEntry cache in HttpRuntime.Cache) {
        toRemove.Add(cache.Key.ToString());
    }
    foreach (string key in cacheList) {
        HttpRuntime.Cache.Remove(key);
    }
