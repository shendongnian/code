	public class FakeDictionary : IDictionary<int, string>
	{
		private readonly string[] _array;
		public FakeDictionary(string[] array)
		{
			_array = array;
		}
		#region IDictionary<int,string> Members
		public void Add(int key, string value)
		{
			throw new NotSupportedException();
		}
		public bool ContainsKey(int key)
		{
			return key >= 0 && key < _array.Length;
		}
		public ICollection<int> Keys
		{
			get { return Enumerable.Range(0, _array.Length).ToArray(); }
		}
		public bool Remove(int key)
		{
			throw new NotSupportedException();
		}
		public bool TryGetValue(int key, out string value)
		{
			value = null;
			if (key >= 0 && key < _array.Length)
			{
				value = _array[key];
				return true;
			}
			return false;
		}
		public ICollection<string> Values
		{
			get { return _array; }
		}
		public string this[int key]
		{
			get
			{
				try
				{
					return _array[key];
				}
				catch (ArgumentOutOfRangeException ex)
				{
					throw new KeyNotFoundException("Invalid key", ex);
				}
			}
			set //note - can't be used to add items
			{
				try
				{
					_array[key] = value;
				}
				catch (ArgumentOutOfRangeException ex)
				{
					throw new KeyNotFoundException("Invalid key", ex);
				}
			}
		}
		#endregion
		#region ICollection<KeyValuePair<int,string>> Members
		public void Add(KeyValuePair<int, string> item)
		{
			throw new NotSupportedException();
		}
		public void Clear()
		{
			throw new NotSupportedException();
		}
		public bool Contains(KeyValuePair<int, string> item)
		{
			return ContainsKey(item.Key) && _array[item.Key].Equals(item.Value);
		}
		public void CopyTo(KeyValuePair<int, string>[] array, int arrayIndex)
		{
			//too much for an SO answer.
			throw new NotImplementedException();
		}
		public int Count
		{
			get { return _array.Length; }
		}
		public bool IsReadOnly
		{
			//technically it's not - because we can modify individual elements - 
			//but at the collection-level it is
			get { return true; }
		}
		public bool Remove(KeyValuePair<int, string> item)
		{
			throw new NotSupportedException();
		}
		#endregion
		#region IEnumerable<KeyValuePair<int,string>> Members
		public IEnumerator<KeyValuePair<int, string>> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		#endregion
		#region IEnumerable Members
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
