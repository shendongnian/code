	public class ChainElement<T> where T : ChainElement<T>
	{
		public T Previous { get; set; }
		public T Next { get; set; }
	}
	public class ChainList<T> : IEnumerable where T : ChainElement<T>
	{
		public T First { get; private set; }
		public void Add(T element)
		{
			if (First != null)
				First.Previous = element;
			element.Next = First;
			First = element;
		}
		public IEnumerator GetEnumerator() { throw new NotImplementedException(); }
	}
	public class Entity<T> : ChainElement<T> where T : ChainElement<T> { }
	public class Item : Entity<Item> { }
