    // Acts as a reference to the current value stored in the list
    private class BoxedValue<T>
    {
        public T Value;
        public BoxedValue(T initialValue) { Value = initialValue; }
    }
    
    public static IObservable<IEnumerable<T>> MergeLatest<T>(this IObservable<IObservable<T>> source)
    {
        return Observable.Create<IEnumerable<T>>(obs =>
        {
            var collection = new PerishableCollection<BoxedValue<T>>();
            var outerSubscription = new SingleAssignmentDisposable();
            var subscriptions = new CompositeDisposable(outerSubscription);
            var innerLock = new object();
            outerSubscription.Disposable = source.Subscribe(duration =>
            {
                BoxedValue<T> value = null;
                var lifetime = new DisposableLifetime(); // essentially a CancellationToken
                var subscription = new SingleAssignmentDisposable();
              
                subscriptions.Add(subscription);
                subscription.Disposable = duration.Synchronize(innerLock)
                    .Subscribe(
                        x =>
                        {
                            if (value == null)
                            {
                                value = new BoxedValue<T>(x);
                                collection.Add(value, lifetime.Lifetime);
                            }
                            else
                            {
                                value.Value = x;
                            }
                            obs.OnNext(collection.CurrentItems().Select(p => p.Value.Value));
                        },
                        obs.OnError, // handle an error in the stream.
                        () => // on complete
                        {
                            if (value != null)
                            {
                                lifetime.Dispose(); // removes the item
                                obs.OnNext(collection.CurrentItems().Select(p => p.Value.Value));
                                subscriptions.Remove(subscription); // remove this subscription
                            }
                        }
                );
            });
            return subscriptions;
        });
    }
