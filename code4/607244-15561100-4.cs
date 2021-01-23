	interface IList<out T> : ICollection<T>
	{
		T this[int index] { get; }
		int IndexOf(object value);
	}
	interface ICollection<out T> : IEnumerable<T>
	{
		int Count { get; }
		bool Contains(object value);
	}
	
