	public static IObservable<T[]> RollingBuffer<T>(
		this IObservable<T> @this,
		TimeSpan buffering)
	{
		return Observable.Create<T[]>(o =>
		{
			var list = new LinkedList<Timestamped<T>>();
			return @this.Timestamp().Subscribe(tx =>
			{
				list.AddLast(tx);
				while (list.First.Value.Timestamp < DateTime.Now.Subtract(buffering))
				{
					list.RemoveFirst();
				}
				o.OnNext(list.Select(tx2 => tx2.Value).ToArray());
			}, ex => o.OnError(ex), () => o.OnCompleted());
		});
	}
