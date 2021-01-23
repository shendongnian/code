	var subject = new Subject<Unit>();
	var closing = Observable
		.Timer(new TimeSpan(0, 0, 1, 30))
		.Select(x => Unit.Default);
	
	var query =
		mFluxObservable
			.Buffer(() => Observable
				.Amb(subject, closing)
				.Take(1));
