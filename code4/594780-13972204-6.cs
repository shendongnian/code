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
		result.Add(new CustomPoint(0, 1));
		result.Add(new CustomPoint(0, 2));
		result.Add(new CustomPoint(0, 3));
		result.Add(new CustomPoint(1, 1));
		result.Add(new CustomPoint(1, 2));
		result.Add(new CustomPoint(1, 3));
		result.Add(new CustomPoint(2, 1));
		result.Add(new CustomPoint(2, 2));
		result.Add(new CustomPoint(2, 3));
		result.Add(new CustomPoint(3, 1));
		result.Add(new CustomPoint(3, 2));
		result.Add(new CustomPoint(3, 3));
		result.Add(new CustomPoint(1, 3));
		result.Add(new CustomPoint(3, 3));
		result.Add(new CustomPoint(0, 2));
		return result;
	}
	
