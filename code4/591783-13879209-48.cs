    static class Functions 
    {
    	// this is where you would do DoSomethingWithContainer(IFoo<?> foo)
    	// with hypothetical java-like wildcards 
    	public static void DoSomethingWithContainer(IFoo foo) 
    	{
    		Console.WriteLine(foo.GetType().ToString());
    	}
        	
    	public static void DoSomethingWithGenericContainer<T>(IFoo<T> el) 
    	{
    		Console.WriteLine(el.Value.GetType().ToString());
    	}
    	
    	public static void DoSomethingWithContent(IFoo<Person> el) 
    	{
    		Console.WriteLine(el.Value.Name);
    	}
    	
    }
