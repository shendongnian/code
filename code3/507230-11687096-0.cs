	public static class Assert
	{
		[ContractAbbreviator]
		public static void GreaterThan<T>(T value, T lowerBound)
			where T : IComparable<T>
		{
			Contract.Ensures(value.CompareTo(lowerBound) > 0);
		}
		
		// ...
	}
	
