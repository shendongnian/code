    var success = new Subject<int>();
    var error = new Subject<int>();
    
    var observables = new List<IObservable<int>> { success.AsObservable(), error.AsObservable() };
    
    observables
    .Select(o => o.Catch((Func<Exception,IObservable<int>>)(e => Observable.Empty<int>())))
    .Merge()
    .Subscribe(Observer.Create<int>(Console.WriteLine, Console.WriteLine, () => Console.WriteLine("done")));
    
    success.OnNext(1);
    error.OnError(new Exception("test"));
    success.OnNext(2);
    success.OnCompleted();
