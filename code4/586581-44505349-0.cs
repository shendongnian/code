    public static class BatchLinq
    {
    	public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
    	{
    		if (size <= 0)
    			throw new ArgumentOutOfRangeException("size", "Must be greater than zero.");
    		using (var enumerator = source.GetEnumerator())
    			while (enumerator.MoveNext())
    			{
    				var i = new BatchInner();
    				var e = i.BatchInner(enumerator, size);
    				yield return e;
    				if (!i.done)
    					e.Count();
    			}
    	}
    
    	private class BatchInner
    	{
    		public bool done = false;
    		
    		public IEnumerable<T> BatchInner<T>(IEnumerator<T> source, int size)
    		{
    			int i = 0;
    			do yield return source.Current;
    			while (++i < size && source.MoveNext());
    			done = true;
    		}
    	}
    }
