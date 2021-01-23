    public partial class HashDictionary<T> : ICollection<T>
    {        
        public void Add(T item)
        {
            this.GetOrAdd(item);
        }
        public bool Contains(T item)
        {
            return this.ContainsKey(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.Keys.CopyTo(array, arrayIndex);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public new IEnumerator<T> GetEnumerator()
        {
            return this.Keys.GetEnumerator();
        }
    }
