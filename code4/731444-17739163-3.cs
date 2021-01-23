    public class DictionaryBuilder<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary
            = new Dictionary<TKey, TValue> dictionary();
        public DictionaryBuilder<TKey, TValue> Add(TKey key, TValue value)
        {
            if (dictionary == null)
            {
                throw new InvalidOperationException("Can't add after building");
            }
            dictionary.Add(key, value);
            return this;
        }
        public Dictionary<TKey, TValue> Build()
        {
            Dictionary<TKey, TValue> ret = dictionary;
            dictionary = null;
            return ret;
        }
    }
