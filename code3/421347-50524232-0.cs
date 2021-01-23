    using System.Collections.Generic;
    namespace Project.Common.Extensions
    {
        public static class DictionaryExtensions
        {
            public static TValue GetValueOrDefault<TKey, TValue>(
                this IDictionary<TKey, TValue> dictionary,
                TKey key,
                TValue defaultValue = default(TValue))
            {
                if (dictionary.TryGetValue(key, out TValue value))
                {
                    return value;
                }
                return defaultValue;
            }
        }
    }
