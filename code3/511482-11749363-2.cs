    public static IObservable<T> WhereTimed<T>(this IObservable<T> source, Func<T,bool> pred, TimeSpan minTime)
    {
        var published = source.Publish().RefCount(); // we make multiple subscriptions, let's share them
    
        var switches = published.Select(pred).DistinctUntilChanged();
        
        return published.Window(switches.Where(x => x), _ => switches.Where(x => !x))
                        .SelectMany(xs => xs.SkipUntil(Observable.Timer(minTime)).TakeWhile(pred));
    }
