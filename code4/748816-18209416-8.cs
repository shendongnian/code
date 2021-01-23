    var observable = Observable.Create<int>(o =>
    {
        o.OnNext(0);
        o.OnCompleted();
        return Disposable.Empty; // using System.Reactive.Disposables;
    });
