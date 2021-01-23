	class Program
	{
		static void Main()
		{
			ConditionalTest();
			SingleLineTest();
			MultiLineTest();
			ConditionalTest();
			SingleLineTest();
			MultiLineTest();
			ConditionalTest();
			SingleLineTest();
			MultiLineTest();
		}
		public static void ConditionalTest()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int count = 0;
			for (uint i = 0; i < 1000000000; ++i) {
				if (i % 16 == 0) ++count;
			}
			stopwatch.Stop();
			Console.WriteLine("Conditional test --> Count: {0}, Time: {1}", count, stopwatch.ElapsedMilliseconds);
		}
		public static void SingleLineTest()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int count = 0;
			for (uint i = 0; i < 1000000000; ++i) {
				count += i % 16 == 0 ? 1 : 0;
			}
			stopwatch.Stop();
			Console.WriteLine("Single-line test --> Count: {0}, Time: {1}", count, stopwatch.ElapsedMilliseconds);
		}
		public static void MultiLineTest()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int count = 0;
			for (uint i = 0; i < 1000000000; ++i) {
				var isMultipleOf16 = i % 16 == 0;
				count += isMultipleOf16 ? 1 : 0;
			}
			stopwatch.Stop();
			Console.WriteLine("Multi-line test  --> Count: {0}, Time: {1}", count, stopwatch.ElapsedMilliseconds);
		}
	}
