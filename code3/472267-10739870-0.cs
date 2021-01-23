    public static class MyExtensions
    {
    	public static List<T> IntersectAll<T>(this IEnumerable<IEnumerable<T>> lists)
    	{
    		HashSet<T> hashSet = new HashSet<T>(lists.First());
    		foreach (var list in lists.Skip(1))
    		{
    			hashSet.IntersectWith(list);
    		}
    		return hashSet.ToList();
    	}
    }
