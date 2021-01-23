    public static IEnumerable<IEnumerable<T>> PowerSet<T>(IEnumerable<T> els)
    {
    	return FilterM(_ => new[] {true, false}, els);
    }
    
    public static IEnumerable<IEnumerable<T>> FilterM<T>(
    	Func<T, IEnumerable<bool>> p,
    	IEnumerable<T> els)
    {
    	var en = els.GetEnumerator();
    	if (!en.MoveNext())
    	{
    		yield return Enumerable.Empty<T>();
    		yield break;
    	}
    
    	T el = en.Current;
    	IEnumerable<T> tail = els.Skip(1);
    	foreach (var x in
    		from flg in p(el)
    		from ys in FilterM(p, tail)
    		select flg ? new[] { el }.Concat(ys) : ys)
    	{
    		yield return x;
    	}
    }
