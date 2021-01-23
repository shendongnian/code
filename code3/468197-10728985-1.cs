    static IObservable<T> Merge<T>(IObservable<T> xs, IObservable<T> ys)
    {
        var map = new Dictionary<IObserver<T>, IObserver<T>>();
        return Observable.Create<T>(
            subscribe: observer =>
            {
                var gate = new object();
                var n = 2;
                var mergeObserver = Observer.Create<T>(
                    x =>
                    {
                        lock (gate)
                            observer.OnNext(x);
                    },
                    ex =>
                    {
                        lock (gate)
                            observer.OnError(ex);
                    },
                    () =>
                    {
                        lock (gate)
                            if (--n == 0)
                                observer.OnCompleted();
                    }
                );
                //
                // Using .Synchronize(gate) would be a mess, because then we need to
                // keep the  two synchronized sequences around as well, such that we
                // can call Unsubscribe on those. So, we're "better off" inlining the
                // locking code in the observer.
                //
                // (Or: how composition goes down the drain!)
                //
                xs.Subscribe(mergeObserver);
                ys.Subscribe(mergeObserver);
                lock (map)
                    map[observer] = mergeObserver;
            },
            unsubscribe: observer =>
            {
                var mergeObserver = default(IObserver<T>);
                lock (map)
                    map.TryGetValue(observer, out mergeObserver);
                if (mergeObserver != null)
                {
                    xs.Unsubscribe(mergeObserver);
                    ys.Unsubscribe(mergeObserver);
                }
            }
        );
    }
