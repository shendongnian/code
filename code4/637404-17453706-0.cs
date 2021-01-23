    public static void Add<TKey,TList,TItem>(this IDictionary<TKey,TList> dict,TKey key,TItem item)
            where TList : ICollection<TItem>,new()
        {
            if(!dict.ContainsKey(key))
            {
                dict.Add(key, new TList());
            }
            dict[key].Add(item);
        }
        public static void Remove<TKey, TList, TItem>(this IDictionary<TKey, TList> dict, TKey key)
            where TList : IEnumerable<TItem>, new()
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
        }
        public static TList Items<TKey, TList, TItem>(this IDictionary<TKey, TList> dict, TKey key)
            where TList : IEnumerable<TItem>, new()
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            return default(TList);            
        }
