    public static class DictionaryExtensions
    {
        public static void UpdateKey<TKye, TValue>(this IDictionary<TKey, TValue> dict, TKey oldKey, TKey newKey){
            TValue value;
            if(dict.TryGetValue(oldKey, out value)){
                  dict.Remove(oldKey);
                  dict.Add(newKey, value);
            }
        }
    }
