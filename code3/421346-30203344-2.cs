    public static class CollectionUtils
    {
        // my original method
        // public static V GetValueOrDefault<K, V>(this Dictionary<K, V> dic, K key)
        // {
        //    V ret;
        //    bool found = dic.TryGetValue(key, out ret);
        //    if (found)
        //    {
        //        return ret;
        //    }
        //    return default(V);
        // }
   
        // EDIT: one of many possible improved versions
        public static TValue GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            // initialized to default value (such as 0 or null depending upon type of TValue)
            TValue value;  
            // attempt to get the value of the key from the dictionary
            dictionary.TryGetValue(key, out value);
            return value;
        }
