    /// <summary>
    /// A dictionary implementation that returns the default value of <typeparamref name="TValue"/> when the key is not present in the dictionary.
    /// </summary>
    public class DictionaryWithDefaults<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Holds the actual data using standard dictionary.
        /// </summary>
        private IDictionary<TKey, TValue> _storage;
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryWithDefaults{TValue}" /> class.
        /// The data is stored directly in this dictionary.
        /// </summary>
        public DictionaryWithDefaults()
        {
            this._storage = new Dictionary<TKey, TValue>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryWithDefaults{TValue}" /> class.
        /// This dictionary acts as a wrapper for the data stored in the dictionary <paramref name="forWrapping" />.
        /// </summary>
        /// <param name="forWrapping">The dictionary object for wrapping.</param>
        /// <exception cref="System.ArgumentNullException">when <paramref name="forWrapping"/> is <c>null</c></exception>
        public DictionaryWithDefaults(IDictionary<TKey, TValue> forWrapping)
        {
            if (forWrapping == null)
                throw new ArgumentNullException("forWrapping");
            this._storage = forWrapping;
        }
        public void Add(TKey key, TValue value)
        {
            this._storage.Add(key, value);
        }
        public bool ContainsKey(TKey key)
        {
            return this._storage.ContainsKey(key);
        }
        public ICollection<TKey> Keys
        {
            get { return this._storage.Keys; }
        }
        public bool Remove(TKey key)
        {
            return this._storage.Remove(key);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            // always return a value, even if the key does not exist.
            // this is also the only place one would modify if the default value has to be customized (passed in the constructor etc.)
            if (!this._storage.TryGetValue(key, out value))
                value = default(TValue);
            
            return true;
        }
        public ICollection<TValue> Values
        {
            get { return this._storage.Values; }
        }
        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                this.TryGetValue(key, out value);
                return value;
            }
            set
            {
                this._storage[key] = value;
            }
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            this._storage.Add(item);
        }
        public void Clear()
        {
            this._storage.Clear();
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return this._storage.Contains(item);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            this._storage.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return this._storage.Count; }
        }
        public bool IsReadOnly
        {
            get { return this._storage.IsReadOnly; }
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return this._storage.Remove(item);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this._storage.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._storage.GetEnumerator();
        }
    }
