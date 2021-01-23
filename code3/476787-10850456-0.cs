	var sub = new Subject<string>();
	var gen = Observable.Interval(TimeSpan.FromMilliseconds(50)).Select((_,i) => i).Subscribe(i => sub.OnNext(i.ToString()));
	
	sub.Sample(TimeSpan.FromSeconds(1))
	   .Subscribe(Console.WriteLine);
	
	Thread.Sleep(3500);
	sub.OnCompleted();
