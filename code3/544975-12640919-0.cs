    List<List<KeyValuePair<T,J>>> buckets; // let's assume this get's allocated somewhere (the dictionary allocates this internally)
    ...
    public J GetValueFromDictionary(T key)
    {
        int bucketIndex = T.GetHashCode() % buckets.Length;
        return buckets[bucketIndex].Find(x => x.Key = key).Single().Value;
    }
    
