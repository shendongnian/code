    public static class DALCache
    {
        static Dictionary<string, object> _AppCache = new Dictionary<string, object>();
    
        public static T GetItem<T>(string key)
        {
            if(_AppCache.ContainsKey(key))
            {
                return (T) _AppCache[key];
            }
            else
            {
                return default(T);
            }
        }
    
        public static void SetItem(string key, object obj)
        {
            _AppCache.Add(key, obj);
        }
    }
