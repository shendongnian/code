    public static class LinqEx
    {
        public static IEnumerable<TResult> 
			LeftOuterJoin<TOuter, TInner, TKey, TResult>(
				this IEnumerable<TOuter> outer, 
				IEnumerable<TInner> inner, 
				Func<TOuter, TKey> outerKeySelector, 
				Func<TInner, TKey> innerKeySelector, 
				Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer
                .GroupJoin(
					inner, 
					outerKeySelector, 
					innerKeySelector, 
					(a, b) => new
					{
						a,
						b
					})
                .SelectMany(
					x => x.b.DefaultIfEmpty(), 
					(x, b) => resultSelector(x.a, b));
        }
    }
