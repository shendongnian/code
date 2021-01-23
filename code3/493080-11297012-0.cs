	void Iterator<T, V>(T collection, Action<V> actor) where T : IEnumerable<V>
	{
		foreach (V value in collection)
			actor(value);
	}
	//Or the more verbose way
	void Iterator<T, V>(T collection, Action<V> actor) where T : IEnumerable<V>
	{
		using (var iterator = collection.GetEnumerator())
		{
			while (iterator.MoveNext())
				actor(iterator.Current);
		}
	}
	//Or if you need to support non-generic collections (ArrayList, Queue, BitArray, etc)
	void Iterator<T, V> (T collection, Action<V> actor) where T : IEnumerable
	{
		foreach (object value in collection)
			actor((V)value);
	}
