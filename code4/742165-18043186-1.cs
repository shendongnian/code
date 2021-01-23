    public IObservable<T> ThrottleDistinct<T>(this IObservable<T> source, TimeSpan delay)
    {
        return Observable.Create(observer =>
        {
            var notifications = new Subject<IObservable<T>>();
            var subscription = notifications.Merge().Subscribe(observer);
            var d = new Dictionary<T, IObserver<T>>();
            var gate = new object();
            var sourceSubscription = new SingleAssignmentDisposable();
            var subscriptions = new CompositeDisposable(subscription, sourceSubscription);
            sourceSubscription.Disposable = source.Subscribe(value =>
            {
               IObserver<T> entry;
               lock(gate)
               {
                 if (d.TryGetValue(value, out entry))
                 {
                   entry.OnNext(value);
                 }
                 else
                 {
                   var s = new Subject<T>();
                   var o = s.Throttle(delay).FirstAsync().Do(() =>
                   {
                     lock(gate)
                     {
                       d.Remove(value);
                     }
                   });
                   notifications.OnNext(o);
                   d.Add(value, s);
                   s.OnNext(value);
                 }
              }
            }, observer.OnError, notifications.OnCompleted);
            return subscriptions;
        });
    }
    ...
    Observable.FromEventPattern(...)
        .Select(e => e.EventArgs.FullPath)
        .ThrottleDistinct(TimeSpan.FromSeconds(1))
        .Subscribe(...);
