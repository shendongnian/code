    public static IEnumerable<T> TakeAndOrder<T>(this IEnumerable<T> items, Func<T, bool> f)
    {		
    	foreach ( var item in items.Where(f))
    		yield return item;
    	foreach (var item in items.Where(i=>!f(i)).OrderBy(i=>i))
    		yield return item;
    }
    
    
    var items = new [] {1, 4, 2, 5, 3};
    items.TakeAndOrder(i=> i == 4);
