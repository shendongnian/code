	static void Main()
	{
		List<int> list = new List<int>(Enumerable.Range(1,10000));
		int total = 0;
		foreach (var i in list)
		{
			total += i;
		}
		IEnumerable<int> enumerable = list;
		foreach (var i in enumerable)
		{
			total += i;
		}
		Console.ReadLine();
	}
