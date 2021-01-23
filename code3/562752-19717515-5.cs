    public static class ObservableExtensions
    {
        public static IObservable<TSource> ReasonableDelay<TSource, TDelay>
            (this IObservable<TSource> source, IObservable<TDelay> delay)
        {
            return Observable.Create<TSource>(observer =>
            {        
                var subscription = new SerialDisposable();
                subscription.Disposable = delay
                    .IgnoreElements()
                    .Subscribe(_ => {}, () => {
                        Console.WriteLine("Waiting to subscribe to source");
                        // Artifical sleep to create a problem
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        Console.WriteLine("Subscribing to source");
                        // Is this line safe?
                        subscription.Disposable = source.Subscribe(observer);
                    }); 
                return subscription;
            });
        }    
    }
