		static void Main(string[] args)
		{
			Console.WriteLine("Method 1 Time Elapsed (ms): {0}", TimeMethod(Method1));
			Console.WriteLine("Method 2 Time Elapsed (ms): {0}", TimeMethod(Method2));
		}
		static long TimeMethod(Action methodToTime)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			methodToTime();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
		static void Method1()
		{
			for (int i = 0; i < 100000; i++)
			{
				for (int j = 0; j < 1000; j++)
				{
				}
			}
		}
		static void Method2()
		{
			for (int i = 0; i < 5000; i++)
			{
			}
		}
	}
