    public static class TypedDictionaryExtension
    {
        public static void Add<T>(this Dictionary<Type, object> dictionary, T value)
        {
            var type = typeof (T);
            if (dictionary.ContainsKey(type))
                dictionary[type] = value;
            else
                dictionary.Add(type, value);
        }
        public static T Get<T>(this Dictionary<Type, object> dictionary)
        {
            // Will throw KeyNotFoundException
            return (T) dictionary[typeof (T)];
        }
        public static bool TryGetValue<T>(this Dictionary<Type, object> dictionary, out T value)
        {
            var type = typeof (T);
            object intermediateResult;
            if (dictionary.TryGetValue(type, out intermediateResult))
            {
                value = (T) intermediateResult;
                return true;
            }
            value = default(T);
            return false;
        }
    }
