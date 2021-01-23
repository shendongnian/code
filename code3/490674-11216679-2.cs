        public static IObservable<T> DeferDisconnection<T>(this IObservable<T> observable, TimeSpan timeout)
        {
            return new ClosingObservable<T>(observable, timeout);
        }
        public class ClosingObservable<T> : IObservable<T>
        {
            private readonly IConnectableObservable<T> Source;
            private readonly IDisposable Subscription;
            private readonly TimeSpan Timeout;
            public ClosingObservable(IObservable<T> observable, TimeSpan timeout)
            {
                Timeout = timeout;
                Source = observable.Publish();
                Subscription = Source.Connect();
            }
            public IDisposable Subscribe(IObserver<T> observer)
            {
                Source.Subscribe(observer);
                return Disposable.Create(() => Source.Select(_ => new Unit())
                                                     .Amb(Observable.Timer(Timeout).Select(_ => new Unit()))
                                                     .Subscribe(_ => Subscription.Dispose())
                                                     );
            }
        }
