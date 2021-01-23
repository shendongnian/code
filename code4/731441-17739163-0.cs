    public class DictionaryBuilder<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary
            = new Dictionary<TKey, TValue> dictionary();
        public void Add(TKey key, TValue value)
        {
            if (dictionary == null)
            {
                throw new InvalidOperationException("Can't add after building);
            }
            dictionary.Add(key, value);
        }
        public Dictionary<TKey, TValue> Build()
        {
            Dictionary<TKey, TValue> ret = dictionary;
            dictionary = null;
            return ret;
        }
    }
