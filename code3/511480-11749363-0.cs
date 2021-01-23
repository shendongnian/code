    public static IObservable<T> WhereTimed<T>(this IObservable<T> source, Func<T,bool> pred, TimeSpan minTime)
    {
        var published = source.Publish().RefCount(); // we make multiple subscriptions, let's share them
        var openers = published.Where(pred);            // start taking at this point
        var closers = published.Where(z => !pred(z));   // stop taking at this point
        
        return openers.SkipUntil(Observable.Timer(minTime))
                      .TakeUntil(closers)
                      .Repeat();
    }
