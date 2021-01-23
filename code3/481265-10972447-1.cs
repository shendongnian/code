    public class KeyValueTuple
    {
        private string key;
        private int value;
        public KeyValueTuple(string key, int value)
        { 
            this.key = key;
            this.value = value;
        }
    }
    public class BigDataCache
    {
        private Dictionary<string, KeyValueTuple> cache;
        public BigDataCache()
        {
            cache = new Dictionary<string, KeyValueTuple>();
            cache.Add("entry1", new KeyValueTuple("entry1", 1));
            cache.Add("entry2", new KeyValueTuple("entry2", 2));
            cache.Add("entry3", new KeyValueTuple("entry3", 3));
        }
        public KeyValueTuple GetTuple(string key)
        {
            KeyValueTuple value = null;
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
