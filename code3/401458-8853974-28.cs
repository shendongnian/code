    public class SomeCollection<T> : IEnumerable<T>
    {
        // implement Add() methods appropriate for your collection
        public void Add(T item)
        {
            // your add logic    
        }
        // implement your enumerators for IEnumerable<T> (and IEnumerable)
        public IEnumerator<T> GetEnumerator()
        {
            // your implementation
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
