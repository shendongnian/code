    public class ReferenceCollection<T> : ICollection<T> where T : myAbstractBase 
    {
        private List<Reference<T>> collection = new List<Reference<T>>();
        public IEnumerable<T> toIEnumerable()
        {
            return (IEnumerable<T>) collection.Select(r => r.Value);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return toIEnumerable().GetEnumerator(); ;
        }
        #region ICollection<T> Members
        public void Add(T item)
        {
            collection.Add(item);
        }
        ...
    }
