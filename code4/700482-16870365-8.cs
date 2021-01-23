        class Section
        {
            public string Header { get; set; }
            public IDictionary<string,string> SubLinkDetails { get; set; }
        }
        public static class IDictionaryX
        {
            public static void RemoveWhere<K,V>(this IDictionary<K,V> dictionary, Predicate<K> condition)
            {
                IEnumerable<K> keysToRemove = dictionary.Keys.Where(k => condition(k));
                foreach (var k in keysToRemove)
                {
                     dictionary.Remove(k);
                }
            }
        }
