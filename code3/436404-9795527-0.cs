    public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
    {
    	IEnumerable<TResult> enumerable = source as IEnumerable<TResult>;
    	if (enumerable != null)
    	{
    		return enumerable;
    	}
    	if (source == null)
    	{
    		throw Error.ArgumentNull("source");
    	}
    	return Enumerable.CastIterator<TResult>(source);
    }
    
    private static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source)
    {
    	foreach (object current in source)
    	{
    		yield return (TResult)current;
    	}
    	yield break;
    }
