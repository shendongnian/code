	public static IEnumerable<V> SelectAggregate<T,V>(this IEnumerable<T> items,V seed,Func<V,T,V> func)
	{
		foreach(var item in items)
		{
			seed	= func(seed,item);
			yield return seed;
		}
	}
    var array = new int[]{ 1,2,3 };
    var sumArray = array.SelectAggregate(0,(seed,item) => seed + item).ToArray();
    //// { 1,3,6 }
