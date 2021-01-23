	public IObservable<int> CreateObservable()
	{
		return Observable.Create<int>(o =>
		{
			var subj = new Subject<int>();
			var disposable = subj.Subscribe(o);
			
			var rnd = new Random();
			var maxValue = rnd.Next(20);
			subj.OnNext(-1);
			for(int iCounter = 0; iCounter < maxValue; iCounter++)
			{
				subj.OnNext(iCounter);
			}
			subj.OnCompleted();
			
			return disposable;
		});
	}
