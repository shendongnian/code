	public static IObservable<T> ExceptionToError<T>(this IObservable<T> source)
	{
		return Observable.Create<T>(o =>
		{
			var subscription = (IDisposable)null;
			subscription = source.Subscribe(x =>
			{
				try
				{
					o.OnNext(x);
				}
				catch (Exception ex)
				{
					o.OnError(ex);
					subscription.Dispose();
				}
			}, e => o.OnError(e), () => o.OnCompleted());
			return subscription;
		});
	}
