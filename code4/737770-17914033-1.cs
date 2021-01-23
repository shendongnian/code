    public static IObservable<IEnumerable<T>> MergeLatest<T>(this IObservable<IObservable<T>> source)
    {
        return Observable.Create<IEnumerable<T>>(obs =>
        {
            var collection = new PerishableCollection<T>();
            return source.Subscribe(duration =>
            {
                var lifetime = new DisposableLifetime(); // essentially a CancellationToken
                duration
                    .Subscribe(
                        x => // on initial item
                        {
                            collection.Add(x, lifetime.Lifetime);
                            obs.OnNext(collection.CurrentItems().Select(p => p.Value));
                        },
                        () => // on complete
                        {
                            lifetime.Dispose(); // removes the item
                            obs.OnNext(collection.CurrentItems().Select(p => p.Value));
                        }
                );
            });
        });
    }
