    public static Dictionary<TKey, IEnumerable<TValue>> Flatten<TKey, TValue>(IEnumerable<Dictionary<TKey, TValue>> dictionaries)
    {
        return dictionaries.SelectMany(d => d.Keys).Distinct().         // IEnumerable<TKey> containing all the keys
            ToDictionary(key => key,
                key => dictionaries.Where(d => d.ContainsKey(key)).     // find Dictionaries that contain the key
                    Select(d => d.First(kvp => kvp.Key.Equals(key))).   // select that key (KeyValuePair<TKey, TValue>)
                    Select(kvp => kvp.Value));                          // and the value
    }
