    public class BigDataCache
    {
        private Dictionary<string, Tuple<string, object>> cache;
        public BigDataCache()
        {
            cache = new Dictionary<string, Tuple<string, object>>();
            cache.Add("entry1", new Tuple<string, object>("entry1", new object()));
            cache.Add("entry2", new Tuple<string, object>("entry2", new object()));
            cache.Add("entry3", new Tuple<string, object>("entry3", new object()));
        }
        public Tuple<string, object> GetTuple(string key)
        {
            Tuple<string, object> value = null;
            if (cache.TryGetValue(key, out value))
            {
                return value;
            }
            return null;
        }
    }
        public void SomeMethod()
        {
            BigDataCache d = new BigDataCache();
            var value1 = d.GetTuple("entry1");
            var value2 = d.GetTuple("entryNotValid");
        }
