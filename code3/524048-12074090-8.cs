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
        public static IEnumerable<TResult> 
            FullOuterJoin<TSet1, TSet2, TKey, TResult>(
                this IEnumerable<TSet1> set1, 
                IEnumerable<TSet2> set2, 
                Func<TSet1, TKey> set1Selector, 
                Func<TSet2, TKey> set2Selector, 
                Func<TSet1, TSet2, TResult> resultSelector)
        {
            var leftJoin = set1.
                LeftOuterJoin(
                    set2, 
                    set1Selector, 
                    set2Selector, 
                    (s1, s2) => new {s1, s2});
            var rightJoin = set2
                .LeftOuterJoin(
                    set1, 
                    set2Selector, 
                    set1Selector, 
                    (s2, s1) => new {s1, s2});
            return leftJoin.Union(rightJoin)
                .Select(x => resultSelector(x.s1, x.s2));
        }
    }
