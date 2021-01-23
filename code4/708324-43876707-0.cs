	public static IEnumerable<IGrouping<TKey, TElement>> Fill<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> groups, IEnumerable<TKey> filling)
	{
		List<TKey> keys = filling.ToList();
		foreach (var g in groups)
		{
			if(keys.Contains(g.Key))
				keys.Remove(g.Key);
			
			yield return g;
		}
		
		foreach(var k in keys)
			yield return new EmptyGrouping<TKey, TElement>(k);
	}
	
	
	class EmptyGrouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
	{
		public TKey Key { get; set; }
		public EmptyGrouping(TKey key)
		{
			this.Key = key;
		}
	}
