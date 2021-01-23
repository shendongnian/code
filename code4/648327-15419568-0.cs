    public class Comparable
    {
        private IDictionary<string, object> _cache;
        
        public Comparable()
        {
            _cache = new Dictionary<string, object>();
        }
        public IDictionary<string, object> Cache { get { return _cache; } }
        protected void Add(string name, object val)
        {
            _cache.Add(name, val);
        }
    }
