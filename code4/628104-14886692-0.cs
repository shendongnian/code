    public static class ListExtensions
    {
    	public static T FromEnd<T>(this IList<T> list, int position)
    	{
    		if (list == null || list.Count == 0)
    		{
    			throw new ArgumentException("list cannot be null or empty");
    		}
    		
    		return list[(list.Count - 1) - position];
    	}
    }
