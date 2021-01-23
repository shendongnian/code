	public class Paircollection<T1, T2> : List<Pair<T1, T2>>
	{
		public List<Pair<T1, T2>> foo = new List<Pair<T1, T2>>();
		public void Add(T1 value1, T2 value2)
		{
			Add(new Pair<T1, T2>(value1, value2));
		}
	}
