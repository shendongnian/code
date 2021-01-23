	public List (IEnumerable <T> collection)
	{
		if (collection == null)
			throw new ArgumentNullException ("collection");
		// initialize to needed size (if determinable)
		ICollection <T> c = collection as ICollection <T>;
		if (c == null) {
			_items = EmptyArray<T>.Value;;
			AddEnumerable (collection);
		} else {
			_size = c.Count;
			_items = new T [Math.Max (_size, DefaultCapacity)];
			c.CopyTo (_items, 0);
		}
	}
	
	void AddEnumerable (IEnumerable <T> enumerable)
	{
		foreach (T t in enumerable)
		{
			Add (t);
		}
	}
