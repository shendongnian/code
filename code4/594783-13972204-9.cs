	static void Main(string[] args)
	{
		List<CustomPoint> list1 = CreateCustomPointList();
		var doubles = GetPointsByCount(GetPointCount(list1), 2);
		Console.WriteLine("Doubles:");
		foreach (var point in doubles)
		{
			Console.WriteLine("X: {0}, Y: {1}", point.X, point.Y);
		}
	}
	private static List<CustomPoint> CreateCustomPointList()
	{
		var result = new List<CustomPoint>();
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				result.Add(new CustomPoint(i, j));
			}
		}
		result.Add(new CustomPoint(1, 3));
		result.Add(new CustomPoint(3, 3));
		result.Add(new CustomPoint(0, 2));
		return result;
	}
	
