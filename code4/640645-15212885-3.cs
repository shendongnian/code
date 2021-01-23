    public static IObservable<T> FirstWithValues<T>(this IEnumerable<IObservable<T>> sources)
    {
        return Observable.Create<T>(obs =>
        {
            // these are neat - if you set it's .Disposable field, and it already
            // had one in there, it'll auto-dispose it
            SerialDisposable disp = new SerialDisposable();
            // this will trigger our exit condition
            bool hadValues = false;
            // start on the first source (assumed to be in order of importance)
            var sourceWalker = sources.GetEnumerator();
            sourceWalker.MoveNext();
            IObserver<T> checker = null;
            checker = Observer.Create<T>(v => 
                {
                    // Hey, we got a value - pass to the "real" observer and note we 
                    // got values on the current source
                    Console.WriteLine("Got value on source:" + v.ToString());
                    hadValues = true;
                    obs.OnNext(v);
                },
                ex => {
                    // pass any errors immediately back to the real observer
                    Console.WriteLine("Error on source, passing to observer");
                    obs.OnError(ex);
                },
                () => {
                    // A source completed; if it generated any values, we're done;                    
                    if(hadValues)
                    {
                        Console.WriteLine("Source completed, had values, so ending");
                        obs.OnCompleted();
                    }
                    // Otherwise, we need to check the next source in line...
                    else
                    {
                        Console.WriteLine("Source completed, no values, so moving to next source");
                        sourceWalker.MoveNext();
                        disp.Disposable = sourceWalker.Current.Subscribe(checker);
                    }
                });
            // kick it off by subscribing our..."walker?" to the first source
            disp.Disposable = sourceWalker.Current.Subscribe(checker);
            return disp.Disposable;
        });
    }
