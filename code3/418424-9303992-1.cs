    public class TrippleKeyDict
    {
        private const char Separator = '|';
        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        public string this[string key1, string key2, string key3]
        {
            get { return _dict[GetKey(key1, key2, key3)]; }
            set { _dict[GetKey(key1, key2, key3)] = value }
        }
        public void Add(string key1, string key2, string key3, string value)
        {
            _dict.Add(GetKey(key1, key2, key3), value);
        }
        public bool TryGetValue(string key1, string key2, string key3, out string result)
        {
            return _dict.TryGetValue(GetKey(key1, key2, key3), out result);
        }
        private static string GetKey(string key1, string key2, string key3)
        {
            return String.Concat(key1, Separator, key2, Separator, key3);
        }
    }
