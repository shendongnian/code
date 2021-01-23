	public static IObservable<IList<T>> SlidingWindow<T>(
		this IObservable<T> src, 
		int windowSize)
	{
		var feed = src.Publish().RefCount();    
		// (skip 0) + (skip 1) + (skip 2) + ... + (skip nth) => return as list  
		return Observable.Zip(
		Enumerable.Range(0, windowSize)
			.Select(skip => 
			{
				Console.WriteLine("Skipping {0} els", skip);
				return feed.Skip(skip);
			})
			.ToArray());
	}
