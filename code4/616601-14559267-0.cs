    public class MySimpleList<T> : MyIList<T>
    {
        public int Count
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }
        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
        object IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public int Add(object value)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }
        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        public void Remove(object value)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
