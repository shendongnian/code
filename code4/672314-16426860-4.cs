    public class Criteria
    {
        private Dictionary<string, object> _criteria = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        public Criteria Set<T>(string key, T value)
        {
            _criteria[key] = value;
            return this;
        } // eo Set
        public T Get<T>(string key)
        {
            return _criteria.ContainsKey(key) ? _criteria[key] : default(T);
        } // eo Get
        public Dictionary<string, object> Items { get { return _criteria; } }
    }    // eo class Criteria
