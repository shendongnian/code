	class Program
	{
		static void Main()
		{
			var addPrm = Expression.Parameter(typeof(int), "i");
			Expression<Func<int, int>> sumExp = 
				Expression.Lambda<Func<int, int>>(
					Expression.Add(
						addPrm,
						addPrm
					),
					addPrm
				);
		} 
	}
