    public class KeyValueList<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }
    public class Program
    {
        public static void Main()
        {
            var list = new KeyValueList<string, string>
                       {
                           { "key1", "value1" },
                           { "key2", "value2" },
                           { "key3", "value3" },
                       };
        }
    }
