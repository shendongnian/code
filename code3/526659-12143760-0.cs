	class MyEquilityTester: IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			return x.Contains(y) || y.Contains(x);
		}
	
		public int GetHashCode(string obj)
		{
			return 0;
		}
	}
