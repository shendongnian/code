    public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> entities, 
                                             string param, params Func<T, string>[] selectors)
    {
    	IEnumerable<T> results = entities;
    	foreach(var selector in selectors)
    	{
    		results = results.Where(l -> …selector(l)…);
    	}
    	return results;
    }
