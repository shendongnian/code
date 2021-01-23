        class MyList<T> : IList<T>
        {
            private readonly IList<T> _list = new List<T>();
            public IEnumerator<T> GetEnumerator()
            {
                return _list.GetEnumerator();
            }
            public void Add(T item)
            {
                _list.Add(item);
            }
            public void Clear()
            {
                _list.Clear();
            }
            public bool Contains(T item)
            {
                return _list.Contains(item);
            }
            public void CopyTo(T[] array, int arrayIndex)
            {
                _list.CopyTo(array, arrayIndex);
            }
            public bool Remove(T item)
            {
                return _list.Remove(item);
            }
            public int Count
            {
                get
                {
                    Console.WriteLine ("Count accessed");
                    return _list.Count;
                }
            }
            public bool IsReadOnly
            {
                get { return _list.IsReadOnly; }
            }
            public int IndexOf(T item)
            {
                return _list.IndexOf(item);
            }
            public void Insert(int index, T item)
            {
                _list.Insert(index, item);
            }
            public void RemoveAt(int index)
            {
                _list.RemoveAt(index);
            }
            public T this[int index]
            {
                get { return _list[index]; }
                set { _list[index] = value; }
            }
            #region Implementation of IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
