    public class ReadOnlyValueCollectionFromDictionary<TDictionary, TKey, TValue> 
                           : ICollection<TValue>
                           where TDictionary : IDictionary<TKey, TValue>, IEnumerable<TValue>
    {
        IDictionary<TKey, TValue> dictionary;
        public ReadOnlyValueCollectionFromDictionary(TDictionary inDictionary)
        {
            dictionary = inDictionary;
        }
        public bool IsReadOnly {
            get { return true; }
        }
        Here I implement ICollection<TValue> by simply calling the corresponding method on 
        the member "dictionary" but I throw a NotSupportedException for the methods Add,
        Remove and Clear
        // I tried to support this one but I cannot compare a TValue with another TValue
        // by using == since the compiler doesn't know if TValue is a struct or a class etc
        // So either I add a generic constraint to only support classes (or ?) or I simply
        // don't support this method since it's ackward in a dictionary anyway to search by
        // value.  Users can still do it themselves if they insist.
        bool IEnumerable<TValue>.Contains(TValue value)
        {
            throw new System.NotSupportedException("A dictionary is not well suited to search by values");
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            return (dictionary as IEnumerable<TValue>).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (dictionary as IEnumerable).GetEnumerator();
        }
    }
    
