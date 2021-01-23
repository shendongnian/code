    int foo = 1;
    Type unboundType = typeof(List<>);
    Type w = unboundType.MakeGenericType(typeof(int));
    
    if (w == typeof(List<int>))
    {
    	Console.WriteLine("Yes its a List<int>");
    	object obj = Activator.CreateInstance(w);
    	
    	try
    	{
    		((List<int>)obj).Add(foo);
    		Console.WriteLine("Success!");
    	}
    	catch(InvalidCastException)
    	{
    		Console.WriteLine("No you can't cast Type");
    	}
    }
