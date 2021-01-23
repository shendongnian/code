    public static class ArrayExtensions
    {
    	public static List<T> MakeAnonymousList<T>(this T[] entries)
    	{
    		return new List<T>(entries);
    	}
    }
