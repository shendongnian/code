    class DictionaryUtils<T>
    {
        public static T ValueOrDefault(IDictionary<string, T> dictionary, string key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default(T);
        }
    }
