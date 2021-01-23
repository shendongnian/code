    static Dictionary<TItem, IEnumerable<TKey>> Invert<TKey, TItem>(Dictionary<TKey, IEnumerable<TItem>> dictionary)
    {
        // Get collection of all the values which will be keys in the new inverted dictionary
        var invertedDictKeys = dictionary.SelectMany(keyValPair => keyValPair.Value).Distinct();
        
        // Perform the invert
        var invertedDict = 
            invertedDictKeys.Select(
                invertedKey => 
                new KeyValuePair<TItem, IEnumerable<TKey>>(invertedKey, dictionary.Keys.Where(key => dict[key].Contains(invertedKey))));
        // Convert to dictionary and return
        return invertedDict.ToDictionary(keyValPair => keyValPair.Key, keyValPair => keyValPair.Value);
    }
