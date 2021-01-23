    public static IObservable<T> RepeatLastValueDuringSilence<T>(this IObservable<T> inner, TimeSpan maxQuietPeriod)
    {
        var published = inner.Publish().RefCount();
    
        return published.Select(x => 
            Observable.Interval(TimeSpan.FromMilliseconds(200))
                    .Select(_ => x)
                    .TakeUntil(published)
                    .StartWith(x)
        ).Concat();
    }
