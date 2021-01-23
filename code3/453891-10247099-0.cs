	public IEnumerator GetEnumerator()
	{
		dict.Keys.GetEnumerator();
	}
	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return dict.Keys.GetEnumerator();
	}
