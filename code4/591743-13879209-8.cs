    static class Functions 
    {
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
