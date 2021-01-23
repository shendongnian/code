    public class ReadOnlyDictionaryWrapper<TKey, TValue, TReadOnlyValue> : IReadOnlyDictionary<TKey, TReadOnlyValue> where TValue : TReadOnlyValue
    {
        private IDictionary<TKey, TValue> _dictionary;
        public ReadOnlyDictionaryWrapper(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) throw new ArgumentNullException("dictionary");
            _dictionary = dictionary;
        }
        public bool ContainsKey(TKey key) { return _dictionary.ContainsKey(key); }
        public IEnumerable<TKey> Keys { get { return _dictionary.Keys; } }
        public bool TryGetValue(TKey key, out TReadOnlyValue value)
        {
            TValue v;
            var result = _dictionary.TryGetValue(key, out v);
            value = v;
            return result;
        }
        public IEnumerable<TReadOnlyValue> Values { get { return _dictionary.Values.Cast<TReadOnlyValue>(); } }
        public TReadOnlyValue this[TKey key] { get { return _dictionary[key]; } }
        public int Count { get { return _dictionary.Count; } }
        public IEnumerator<KeyValuePair<TKey, TReadOnlyValue>> GetEnumerator()
        {
            foreach (var item in _dictionary)
            {
                yield return new KeyValuePair<TKey, TReadOnlyValue>(item.Key, item.Value);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
