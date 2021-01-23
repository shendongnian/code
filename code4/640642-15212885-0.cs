    public static IObservable<T> FirstWithValues<T>(this IEnumerable<IObservable<T>> sources)
    {
        return Observable.Create<T>(obs =>
        {
            SerialDisposable disp = new SerialDisposable();
            bool hadValues = false;
            var sourceWalker = sources.GetEnumerator();
            sourceWalker.MoveNext();
            IObserver<T> checker = null;
            checker = Observer.Create<T>(v => 
                {
                    Console.WriteLine("Got value on source:" + v.ToString());
                    hadValues = true;
                    obs.OnNext(v);
                },
                ex => {
                    Console.WriteLine("Error on source, passing to observer");
                    obs.OnError(ex);
                },
                () => {
                    if(hadValues)
                    {
                        Console.WriteLine("Source completed, had values, so ending");
                        obs.OnCompleted();
                    }
                    else
                    {
                        Console.WriteLine("Source completed, no values, so moving to next source");
                        sourceWalker.MoveNext();
                        disp.Disposable = sourceWalker.Current.Subscribe(checker);
                    }
                });
            disp.Disposable = sourceWalker.Current.Subscribe(checker);
            return disp.Disposable;
        });
    }
