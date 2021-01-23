    public static IObservable<TSource> SkipWhile<TSource>(this IObservable<TSource> source, Func<TSource, bool> predictate, TimeSpan dueTime)
    {
        return Observable.Create<TSource>(
            o => source
                        .Subscribe(value =>
                                    {
                                        bool running;
    
                                        try
                                        {
                                            running = !predictate(value);
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
