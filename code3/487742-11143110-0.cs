    public static TSource Last<TSource>(this IEnumerable<TSource> source)
    {
    	if (source == null)
    	{
    		throw Error.ArgumentNull("source");
    	}
    	IList<TSource> list = source as IList<TSource>;
    	if (list != null)
    	{
    		int count = list.Count;
    		if (count > 0)
    		{
    			return list[count - 1];
    		}
    	}
    	else
    	{
    		using (IEnumerator<TSource> enumerator = source.GetEnumerator())
    		{
    			if (enumerator.MoveNext())
    			{
    				TSource current;
    				do
    				{
    					current = enumerator.Current;
    				}
    				while (enumerator.MoveNext());
    				return current;
    			}
    		}
    	}
    	throw Error.NoElements();
    }
