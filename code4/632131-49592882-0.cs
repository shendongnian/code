    using System.Linq;
    
    namespace System.Collections.Generic
    {
    
        /// <summary>
        /// 
        /// </summary>
        public static class IDictionaryExtensions
        {
    
            public static bool ContainsKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
            {
                return keys.Any() && keys.All(key => dictionary.ContainsKey(key));
            }
    
        }
    
    }
