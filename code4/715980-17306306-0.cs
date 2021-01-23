	public static void Main()
	{
		int n = 1;
		Test(ref n);
		Console.WriteLine(n); //will print out 2 and not 1.
		Console.ReadKey(true);
	}
	public static void Test(ref int x)
	{
		x = 2;
	}
