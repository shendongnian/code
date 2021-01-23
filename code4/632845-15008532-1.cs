    [ObsoleteAttribute(@"The second data source of a binary operator 
                        must be of type System.Linq.ParallelQuery<T> 
                        rather than System.Collections.Generic.IEnumerable<T>. 
                        To fix this problem, use the AsParallel() extension
                        method to convert the right data source to
                        System.Linq.ParallelQuery<T>.")]
    public static ParallelQuery<TResult> Join<TOuter, TInner, TKey, TResult>(
    	this ParallelQuery<TOuter> outer,
    	IEnumerable<TInner> inner,
    	Func<TOuter, TKey> outerKeySelector,
    	Func<TInner, TKey> innerKeySelector,
    	Func<TOuter, TInner, TResult> resultSelector
    )
