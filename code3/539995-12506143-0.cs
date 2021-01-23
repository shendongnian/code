	public delegate void F(int x);
	
	public static void Main()
	{
		F f = null;
		f += x => System.Console.WriteLine("First: {0}", x);
		f += x => System.Console.WriteLine("Second: {0}", x);
		f(5);
	}
