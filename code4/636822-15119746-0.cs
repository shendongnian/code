    public static class CollectionExtensions
    {    
        public static SerializableDictionary<TKey, TValue> ToSerializableDictionary<T, TKey, TValue>(
           this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
        {
            var dict = new SerializableDictionary<TKey, TValue>();
            foreach (T item in source)
            {
                TKey key = keySelector(item);
                TValue value = valueSelector(item);
                dict.Add(key, value);
            }
    
            return dict;
        }
    } 
