    public static IObservable<T> DelayBetweenValues<T>(this IObservable<T> observable, TimeSpan interval,
        IScheduler scheduler)
    {
            var offset =  TimeSpan.Zero;
            return observable
                .TimeInterval(scheduler)
                .Delay(ti =>
                {
                    offset = (ti.Interval < interval) ? offset.Add(interval) : TimeSpan.Zero;
                    return Observable.Timer(offset);
                })
                .Select(ti => ti.Value);
    }
