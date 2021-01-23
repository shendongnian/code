    public class HashSet<T> : IEnumerable<T>
    {
        private Dictionary<T, object> _dictionary = new Dictionary<T, object>();
        public void Add(T value)
        {
            if (!_dictionary.ContainsKey(value))
                _dictionary.Add(value, null);
        }
        public void Remove(T value)
        {
            _dictionary.Remove(value);
        }
        public void Clear()
        {
            _dictionary.Clear();
        }
        public int Count 
        { 
            get { return _dictionary.Count; } 
        }
    
        public IEnumerator<T>  GetEnumerator()
        {
            return _dictionary.Keys.GetEnumerator();
        }
        // ...
    }
