    public class NavigationUri : Uri, IDictionary<Type, object>
    {
        private IDictionary<Type, object> _internalDictionary = new Dictionary<Type, object>();
 
        public NavigationUri(string uriString) : base(uriString, UriKind.Relative)
        {
        }
        public NavigationUri(string uriString, UriKind uriKind) :  base(uriString, uriKind)
        {
        }
 
        public void Add<T>(T value)
        {
            Add(typeof(T), value);
        }
 
        public void Add(Type key, object value)
        {
            _internalDictionary.Add(key, value);
        }
 
        public bool ContainsKey<T>()
        {
            return ContainsKey(typeof (T));
        }
 
        public bool ContainsKey(Type key)
        {
            return _internalDictionary.ContainsKey(key);
        }
 
        public ICollection<Type> Keys
        {
            get { return _internalDictionary.Keys; }
        }
 
        public bool Remove<T>()
        {
            return Remove(typeof (T));
        }
 
        public bool Remove(Type key)
        {
            return _internalDictionary.Remove(key);
        }
 
        public bool TryGetValue<T>(out object value)
        {
            return TryGetValue(typeof (T), out value);
        }
 
        public bool TryGetValue(Type key, out object value)
        {
            return _internalDictionary.TryGetValue(key, out value);
        }
 
        public ICollection<object> Values
        {
            get { return _internalDictionary.Values; }
        }
 
        public object this[Type key]
        {
            get { return _internalDictionary[key]; }
            set { _internalDictionary[key] = value; }
        }
 
        public void Add(KeyValuePair<Type, object> item)
        {
            _internalDictionary.Add(item);
        }
 
        public void Clear()
        {
            _internalDictionary.Clear();
        }
 
        public bool Contains(KeyValuePair<Type, object> item)
        {
            return _internalDictionary.Contains(item);
        }
 
        public void CopyTo(KeyValuePair<Type, object>[] array, int arrayIndex)
        {
            _internalDictionary.CopyTo(array, arrayIndex);
        }
 
        public int Count
        {
            get { return _internalDictionary.Count; }
        }
 
        public bool IsReadOnly
        {
            get { return _internalDictionary.IsReadOnly; }
        }
 
        public bool Remove(KeyValuePair<Type, object> item)
        {
            return _internalDictionary.Remove(item);
        }
 
        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }
 
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }
    }
