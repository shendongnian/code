	class Program
	{
		static void Main(string[] args)
		{
			double[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			double target = 7;
			if (target < values.Min() || target > values.Max())
				throw new Exception("Out of bounds");
			int smallerCount = values.Where(x => x < target).Count();
			int largerCount = values.Where(x => x > target).Count();
			Console.WriteLine(smallerCount / (smallerCount + largerCount));
			Console.ReadLine();
		}
	}
