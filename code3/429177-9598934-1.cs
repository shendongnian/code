    private static void Main(string[] args)
    {
    	foreach (var z in MyClass.Test())
    	{
    		Console.WriteLine(z);
    	}
    
    	var f = MyClass.Test2()[0];
    
    	Console.ReadKey();
    }
