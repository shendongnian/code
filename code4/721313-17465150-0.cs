    sealed class DictionaryWrapper<K, T> : ICollection<T>
    {
        private readonly Func<T, K> m_keyProjection ;
        private readonly IDictionary<K, T> m_dictionary ;
        // expose the wrapped dictionary
        public IDictionary<K, T> Dictionary { get { return m_dictionary ; }}
        public void Add (T value)
        {
            m_dictionary[m_keyProjection (value)] = value ;
        }
        public IEnumerator<T> GetEnumerator ()
        {
            return m_dictionary.Values.GetEnumerator () ;
        }
        // the rest is left as excercise for the reader
    }
