	public sealed class NonGenericList<T> : IList
	{
		private readonly IList<T> _wrappedList;
		public NonGenericList(IList<T> wrappedList)
		{
			if(wrappedList == null) throw new ArgumentNullException("wrappedList");
			_wrappedList = wrappedList;
		}
		public int Add(object value)
		{
			_wrappedList.Add((T)value);
			return _wrappedList.Count - 1;
		}
		public void Clear()
		{
			_wrappedList.Clear();
		}
		public bool Contains(object value)
		{
			return _wrappedList.Contains((T)value);
		}
		public int IndexOf(object value)
		{
			return _wrappedList.IndexOf((T)value);
		}
		public void Insert(int index, object value)
		{
			_wrappedList.Insert(index, (T)value);
		}
		public bool IsFixedSize
		{
			get { return false; }
		}
		public bool IsReadOnly
		{
			get { return _wrappedList.IsReadOnly; }
		}
		public void Remove(object value)
		{
			_wrappedList.Remove((T)value);
		}
		public void RemoveAt(int index)
		{
			_wrappedList.RemoveAt(index);
		}
		public object this[int index]
		{
			get { return _wrappedList[index]; }
			set { _wrappedList[index] = (T)value; }
		}
		public void CopyTo(Array array, int index)
		{
			_wrappedList.CopyTo((T[])array, index);
		}
		public int Count
		{
			get { return _wrappedList.Count; }
		}
		public bool IsSynchronized
		{
			get { return false; }
		}
		public object SyncRoot
		{
			get { return this; }
		}
		public IEnumerator GetEnumerator()
		{
			return _wrappedList.GetEnumerator();
		}
	}
