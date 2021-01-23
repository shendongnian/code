	class Program
	{
        // expect it to be 10 times less in real code
		static int max = 455;
		static void Test(int i)
		{
			try {
				if (i >= max) throw new Exception("done");
				Test(i + 1);
			}
			catch {
				Console.WriteLine(i);
				throw;
			}
		}
		static void Main(string[] args)
		{
			try {
				Test(0);
			}
			catch {
			}
			Console.WriteLine("Done.");
		}
	}
