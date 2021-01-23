    class Program
	{
		static void Main(string[] args)
		{
			var map = new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 1 } };
			var result = map.Distinct(new MyComparer());
		}
		class MyComparer : IEqualityComparer<KeyValuePair<int, int>>
		{
			public bool Equals(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
			{
				return x.Value == y.Value;
			}
			public int GetHashCode(KeyValuePair<int, int> obj)
			{
				return 1;
			}
		}
	}
