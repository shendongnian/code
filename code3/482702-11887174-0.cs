    var messages = Observable.Interval(TimeSpan.FromMilliseconds(100));
    
    messages.Chunkify()
            .ToObservable()
            .Where(list => list.Any())
            .Select(list => list.Last())
            .Subscribe(n =>
            {
              Thread.Sleep(TimeSpan.FromMilliseconds(250));
    	      Console.WriteLine(n);
            });
