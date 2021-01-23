    void Main()
    {
    	var elements = Enumerable.Range(0,20);
    	elements.ForEachWithElse(x=>Console.WriteLine (x),
    							()=>Console.WriteLine ("no elements at all"));
    							
    	elements.Take(0).ForEachWithElse(x=>Console.WriteLine (x),
    							()=>Console.WriteLine ("no elements at all"));
    }
    public static class MyExtensions
    {    
    	public static void ForEachWithDefault<T>(this IEnumerable<T> values, Action<T> function, Action emptyBehaviour)
    	{
    		if(values.Any())
    			values.ToList().ForEach(function);
    		else 
    			emptyBehaviour();
    	}
    }
