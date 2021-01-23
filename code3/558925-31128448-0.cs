    namespace System.Collection.Generic
    {
        public static class DictionaryExtensions
        {
            public static void AddKeyValuePair<K,V>(this IDictionary<K, V> me, KeyValuePair<K, V> other)
            {
                me.Add(other.Key, other.Value);
            }
        }
    }
