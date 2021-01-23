    var freq = new OrderedDictionary<string, int>();
    // ...
    foreach (var entry in freq)
    {
        var word = entry.Key;
        var wordFreq = entry.Value;
        int termIndex = GetIndex(freq, entry.Key);
    }
    public int GetIndex(OrderedDictionary<string, object> dictionary, key string) 
    {
        for(int index = 0; index < dictionary.Count; index++)
        {
            if (dictionary.Item[index] == dictionary.Item[key]) 
                return i;
        }
        return -1;
    }
