    public static class Linq
    {
        // We take in some data structure that supports enumeration and some function to apply to each element.
    	public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> operation)
    	{
    		foreach (var item in source)
    		{
                // Here we simply return the next element
                // when the caller wants an item.
    			yield return operation(item);
    		}
    	}
    }
