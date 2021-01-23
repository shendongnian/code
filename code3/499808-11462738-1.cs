    public static IObservable<T> RepeatLastValueDuringSilence<T>(this IObservable<T> inner, TimeSpan maxQuietPeriod)
    {
        var throttled = inner.Throttle(maxQuietPeriod);
        var repeating = throttled.SelectMany(i => 
            Observable
                .Interval(maxQuietPeriod)
                .Select(_ => i)
                .TakeUntil(inner));
        return Observable.Merge(inner, throttled, repeating);
    }
