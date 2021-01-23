    private static void Main(string[] args)
    {
    	object obj = new Test();
    	if (obj is Test)
    	{
    		Console.WriteLine("test1");
    	}
    	if (obj is Test)
    	{
    		Console.WriteLine("test2");
    	}
    }
