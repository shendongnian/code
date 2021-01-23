    public static class EnumerableEx
    {
    	public static IEnumerable<T> Repeat<T>(int amt, Func<T> producer)
    	{
    		for(var i = 0; i < amt; ++i)
    		{
    			yield return producer();
    		}
    	}
    }
