    public class MyDictionary : IDictionary<SomeKey,SomeValue>, 
                                IEnumerable<SomeKey>, 
                                IEnumerable<SomeValue>
    {
        IEnumerator<SomeKey> IEnumerable<SomeKey>.GetEnumerator()
        {
            for ( int i = 0; i < nbElements; ++i )
            {
                yield return GetKeyAt(i);
            }
        }
        IEnumerator<SomeValue> IEnumerable<SomeValue>.GetEnumerator()
        {
            for ( int i = 0; i < nbElements; ++i )
            {
                yield return GetValueAt(i);
            }
        }
        // IEnumerator IEnumerable.GetEnumerator() is already implemented in the dictionary
        public ICollection<SomeKey> Keys
        {
            get
            {
                return new ReadOnlyKeyCollectionFromDictionary< MyDictionary, SomeKey, SomeValue>(this);
            }
        }
        public ICollection<Value> Values
        {
            get
            {
                return new ReadOnlyValueCollectionFromDictionary< MyDictionary, SomeKey, SomeValue >(this);
            }
        }
    }
