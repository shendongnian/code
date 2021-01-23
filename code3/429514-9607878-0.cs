    IObservable<T> Poll<T>(this IObservable<T> source, TimeSpan interval)
    {
        //error checking goes here
        return source.CombineLatest(Observable.Interval(interval),
                                    Tuple.Create)
                     .Scan(Tuple.Create(string.Empty, -1L, -1L),
                           (a, t) => Tuple.Create(t.Item1, t.Item2, a.Item2))
                     .Where(t => t.Item2 != t.Item3)
                     .Select(t => t.Item1);
    }
