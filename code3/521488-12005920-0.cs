	public sealed class X
	{
		public float Property { get; set; }
	}
	static void Test()
	{
		var arr = new X[]
		{
			new X { Property = 5.5f },
			new X { Property = 2.5f },
			new X { Property = 6.5f },
			new X { Property = 1.2f },
		};
		Array.Sort(arr, (a, b) => a.Property.CompareTo(b.Property));
	}
