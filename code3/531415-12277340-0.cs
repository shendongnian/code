	public static IObservable<T> FirstOrLastAsync<T>(
		this IObservable<T> source, Func<T, bool> pred)
	{
		return Observable.Create<T>(o =>
		{
			var hot = source.Publish();
			var store = new AsyncSubject<T>();
			var d1 = hot.Subscribe(store);
			var d2 =
				hot
					.Where(x => pred(x))
					.Concat(store)
					.Take(1)
					.Subscribe(o);
			var d3 = hot.Connect();
			return new CompositeDisposable(d1, d2, d3);
		});
	}
