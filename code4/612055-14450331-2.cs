    public static IObservable<TSource> DelayWhile<TSource>(this IObservable<TSource> source, Func<TSource, bool> predicate, TimeSpan dueTime)
    {
        return Observable.Create<TSource>(
            o => source
                        .Subscribe(value =>
                                    {
                                        bool running;
    
                                        try
                                        {
                                            running = !predicate(value);
                                        }
                                        catch (Exception ex)
                                        {
                                            o.OnError(ex);
    
                                            return;
                                        }
    
                                        if (!running)
                                        {
                                            Thread.Sleep(dueTime);
                                            return;
                                        }
    
                                        o.OnNext(value);
                                    },
                                o.OnError,
                                o.OnCompleted));
    }
