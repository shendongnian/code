	public static IEnumerable<IEnumerable<T>> SplitBetween<T>(this IEnumerable<T> source,
															  Func<T,bool> separatorSelector, 
															  bool includeSeparators=false) 
	{
		if (source == null)
			throw new ArgumentNullException("source");
			
		return SplitBetweenImpl(source, separatorSelector, includeSeparators);
	}
	
	private static IEnumerable<T> SplitBetweenInner<T>(IEnumerator<T> e,
													   Func<T,bool> separatorSelector)
	{
		var first = true;
				
		while(first || e.MoveNext())
		{
			if (separatorSelector((T)e.Current))
				yield break;	
				
			first = false;
			yield return e.Current;
		}
	}
	
	private static IEnumerable<IEnumerable<T>> SplitBetweenImpl<T>(this IEnumerable<T> source,
															       Func<T,bool> separatorSelector, 
															       bool includeSeparators) 
	{
		using (var e = source.GetEnumerator())
			while(e.MoveNext())
			{
				if (separatorSelector((T)e.Current) && includeSeparators)
					yield return new T[] {(T)e.Current};
				else
					{
					yield return SplitBetweenInner(e, separatorSelector);
					if (separatorSelector((T)e.Current) && includeSeparators)
						yield return new T[] {(T)e.Current};
					}
			}
	}
