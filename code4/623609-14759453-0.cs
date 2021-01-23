    public class ReadOnlyKeyCollectionFromDictionary< TDictionary, TKey, TValue >
                           : ICollection<TKey>
                           where TDictionary : IDictionary<TKey,TValue>, IEnumerable<TKey>
    {
        IDictionary<TKey, TValue> dictionary;
        public ReadOnlyKeyCollectionFromDictionary(TDictionary inDictionary)
        {
            dictionary = inDictionary;
        }
        public bool IsReadOnly {
            get { return true; }
        }
        Here I implement ICollection<TKey> by simply calling the corresponding method on 
        the member "dictionary" but I throw a NotSupportedException for the methods Add,
        Remove and Clear
        public IEnumerator<TKey> GetEnumerator()
        {
            return (dictionary as IEnumerable<TKey>).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (dictionary as IEnumerable).GetEnumerator();
        }
    }
