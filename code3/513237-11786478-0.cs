	private static void AreSameParameter(out int one, out int two)
	{
		one = 1;
		two = 1;
		one = 2;
		if (two == 2)
			Console.WriteLine("Same");
		else
			Console.WriteLine("Different");
	}
	
	static void Main(string[] args)
	{
		int a;
		int b;
		AreSameParameter(out a, out a);	// Same
		AreSameParameter(out a, out b);	// Different
		Console.ReadLine();
	}
