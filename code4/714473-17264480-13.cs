    /// <summary>
    /// A System.Attribute which is also an IDictionary, useful for adding extension data to 
    /// individual objects, no matter the type
    /// </summary>
    public class ExtensionDataAttribute : System.Attribute, IDictionary<string, object>
    {
        // The dictionary wrapped by this collection, which cannot extend by System.Attribute and Dictionary at once
        private IDictionary<string, object> data = new Dictionary<string, object>();
        
        /// <summary>
        /// Adds this collection of extension data to the specified object; should be called only once
        /// </summary>
        /// <param name="o">The object to which to add this collection of extension data</param>
        public void AddTo(object o) {
            System.ComponentModel.TypeDescriptor.AddAttributes(o, this);
        }
        
        // Following are encapsulated calls to the wrapped dictionary, which should need no explanation; 
        // after accessing an ExtensionDataAttribute instance, simply use it as an IDictionary<string, object>
        
        public void Add(string key, object value)
        {
            data.Add(key, value);
        }
        
        public bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }
        
        public ICollection<string> Keys
        {
            get { return data.Keys; }
        }
        
        public bool Remove(string key)
        {
            return data.Remove(key);
        }
        
        public bool TryGetValue(string key, out object value)
        {
            return data.TryGetValue(key, out value);
        }
        
        public ICollection<object> Values
        {
            get { return data.Values; }
        }
        
        public object this[string key]
        {
            get
            {
                return data[key];
            }
            set
            {
                data[key] = value;
            }
        }
        
        public void Add(KeyValuePair<string, object> item)
        {
            data.Add(item);
        }
        
        public void Clear()
        {
            data.Clear();
        }
        
        public bool Contains(KeyValuePair<string, object> item)
        {
            return data.Contains(item);
        }
        
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }
        
        public int Count
        {
            get { return data.Count; }
        }
        
        public bool IsReadOnly
        {
            get { return data.IsReadOnly; }
        }
        
        public bool Remove(KeyValuePair<string, object> item)
        {
            return data.Remove(item);
        }
        
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return data.GetEnumerator();
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
