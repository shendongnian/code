    public static IDisposable SubscribeWithoutOverlap<T>(this IObservable<T> source, Action<T> action)
    {
        var sampler = new Subject<Unit>();
        
        var sub = source.
            Sample(sampler).
            ObserveOn(Scheduler.ThreadPool).
            Subscribe(l =>
            {
                action(l);
                sampler.OnNext(Unit.Default);
            });
        
        // start sampling when we have a first value
        source.Take(1).Subscribe(_ => sampler.OnNext(Unit.Default));
        
        return sub;
    }
