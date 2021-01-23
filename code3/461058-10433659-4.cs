        public class KeyValue<TKey, TValue>
        {
            public KeyValue()
            {
            }
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public static List<KeyValue<TKey,TValue>> ConvertDictionary
                (Dictionary<TKey,TValue> dictionary)
            {
                List<KeyValue<TKey, TValue>> newList
                    = new List<KeyValue<TKey, TValue>>();
                foreach (TKey key in dictionary.Keys)
                {
                    newList.Add(new KeyValue<TKey, TValue> 
                      { Key = key, Value = dictionary[key] });
                }
                return newList;
            }
        }
