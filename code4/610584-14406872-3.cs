    public shared void ToArrays<K,V>(this IEnumerable<KeyValuePair<K,V>> pairs, 
        out K[] keys, out V[] values)
    {
       var keyList = new List<K>();
       var valueList = new List<V>();
       foreach (KeyValuePair<K,V> pair in pairs)
       {
          keyList.Add(pair.Key);
          valueList.Add(pair.Value);
       }
       keys = keyList.ToArray();
       values = valueList.ToArray();
    }
