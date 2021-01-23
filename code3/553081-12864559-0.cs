    public Dictionary<TKey, TValue>[] dictionaries;
    private readonly int numDictionaries = 5;
    public NonContigousDictionary()
    {
        dictionaries = Enumerable.Range(0, numDictionaries)
            .Select(_ => new Dictionary<TKey, TValue>())
            .ToArray();
    }
    public TValue this[TKey key]
    {
        get
        {
            int hash = key.GetHashCode();
            return dictionaries[hash / numDictionaries][key];
        }
        set
        {
            int hash = key.GetHashCode();
            dictionaries[hash / numDictionaries][key] = value;
        }
    }
    public bool Remove(TKey key)
    {
        int hash = key.GetHashCode();
        return dictionaries[hash / numDictionaries].Remove(key);
    }
    public void Clear()
    {
        foreach (var dic in dictionaries)
        {
            dic.Clear();
        }
    }
}
