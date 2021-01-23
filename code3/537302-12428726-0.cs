    public static class DictionaryExtensions
    {
        public static TValue GetRefStat<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) 
        {
            return dictionary[key];
        }
    }
