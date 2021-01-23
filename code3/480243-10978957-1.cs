	var success = new Subject<int>();
	var error = new Subject<int>();
	
	var observables = new List<IObservable<int>> { Observable.Defer(() => {success = new Subject<int>(); return success.AsObservable();}), 
	                                               Observable.Defer(() => {error = new Subject<int>(); return error.AsObservable();}) };	                                        
	
	observables
	.Select(o => o.Retry())
	.Merge()
	.Subscribe(Console.WriteLine, Console.WriteLine, () => Console.WriteLine("done"));
