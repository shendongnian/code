    public class NonContigousDictionary<TKey, TValue>
    //TODO make this implement IEnumerable, IDictionary, 
    //and any other relevant interfaces.
    {
        public Dictionary<TKey, TValue>[] dictionaries;
        private readonly int numDictionaries = 5;
        public NonContigousDictionary()
        {
            dictionaries = Enumerable.Range(0, numDictionaries)
                .Select(_ => new Dictionary<TKey, TValue>())
                .ToArray();
        }
        public TValue this[TKey key]
        {
            get
            {
                int hash = key.GetHashCode();
                return dictionaries[GetBucket(hash)][key];
            }
            set
            {
                int hash = key.GetHashCode();
                dictionaries[GetBucket(hash][key] = value;
            }
        }
        public bool Remove(TKey key)
        {
            int hash = key.GetHashCode();
            return dictionaries[GetBucket(hash].Remove(key);
        }
        public void Clear()
        {
            foreach (var dic in dictionaries)
            {
                dic.Clear();
            }
        }
        private int GetBucket(int hash)
        {
            return (hash % numDictionaries + numDictionaries) % numDictionaries;
        }
    }
