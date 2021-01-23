    class AddFirstList<T> : IEnumerable<T>, IReadOnlyList<T>
    {
        private readonly List<T> m_list = new List<T>();
        public void AddFirst(T item)
        {
            m_list.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Enumerable.Reverse(m_list).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public int Count
        {
            get { return m_list.Count; }
        }
        public T this[int index]
        {
            get { return m_list[Count - index - 1]; }
        }
    }
