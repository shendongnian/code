	static int MultiHash(IEnumerable<object> items)
	{
		Contract.Requires(items != null);
		int h = 0;
		foreach (object item in items)
		{
			 h = Combine(h, item != null ? item.GetHashCode() : 0);
		}
		return h;
	}
	static int Combine(int x, int y)
	{
		unchecked
		{
			 // This isn't a particularly strong way to combine hashes, but it's
			 // cheap, respects ordering, and should work for the majority of cases.
			 return (x << 5) + 3 + x ^ y;
		}
	}
