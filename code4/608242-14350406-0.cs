    public class LazyReversingList<T> : IList<T>
    {
        private Boolean m_SortedAscending;
        private List<T> m_InnerList;
        public Boolean IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public Boolean SortedAscending
        {
            get
            {
                return m_SortedAscending;
            }
        }
        public Int32 Count
        {
            get
            {
                EnsureList();
                return m_InnerList.Count;
            }
        }
        public T this[Int32 index]
        {
            get
            {
                EnsureList();
                return m_InnerList[index];
            }
            set
            {
                EnsureList();
                m_InnerList[index] = value;
            }
        }
        private void EnsureList()
        {
            if (m_InnerList == null)
                m_InnerList = new List<T>();
        }
        public Boolean Contains(T item)
        {
            EnsureList();
            return m_InnerList.Contains(item);
        }
        public Boolean Remove(T item)
        {
            EnsureList();
            return m_InnerList.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            EnsureList();
            return m_InnerList.GetEnumerator();
        }
        public Int32 IndexOf(T item)
        {
            EnsureList();
            return m_InnerList.IndexOf(item);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            EnsureList();
            return m_InnerList.GetEnumerator();
        }
        public void Add(T item)
        {
            EnsureList();
            m_InnerList.Add(item);
        }
        public void Clear()
        {
            EnsureList();
            m_InnerList.Clear();
        }
        public void CopyTo(T[] array, Int32 arrayIndex)
        {
            EnsureList();
            m_InnerList.CopyTo(array, arrayIndex);
        }
        public void Insert(Int32 index, T item)
        {
            EnsureList();
            m_InnerList.Insert(index, item);
        }
        public void RemoveAt(Int32 index)
        {
            EnsureList();
            m_InnerList.RemoveAt(index);
        }
        public void Reverse()
        {
            if (!m_SortedAscending)
            {
                m_InnerList.Sort((x, y) => String.CompareOrdinal(x.DisplayName, y.DisplayName));
                m_SortedAscending = true;
            }
            else
            {
                m_InnerList.Sort((x, y) => (String.CompareOrdinal(x.DisplayName, y.DisplayName) * -1));
                m_SortedAscending = false;
            }
        }
    }
