    public class ObservableRouter<T> : IObservable<T>
    {
        ISubject<T> _Subject = new Subject<T>();
        Dictionary<IObserver<T>, IDisposable> _ObserverSubscriptions 
                                   = new Dictionary<IObserver<T>, IDisposable>();
        IObservable<T> _ObservableSource;
        IDisposable _SourceSubscription;
        //Note that this can happen before or after SetSource
        public IDisposable Subscribe(IObserver<T> observer)
        {
            _ObserverSubscriptions.Add(observer, _Subject.Subscribe(observer));
            IfReadySubscribeToSource();
            return Disposable.Create(() => UnsubscribeObserver(observer));
        }
        //Note that this can happen before or after Subscribe
        public void SetSource(IObservable<T> observable)
        {
            if(_ObserverSubscriptions.Count > 0 && _ObservableSource != null) 
                      throw new InvalidOperationException("Already routed!");
            _ObservableSource = observable;
            IfReadySubscribeToSource();
        }
        private void IfReadySubscribeToSource()
        {
            if(_SourceSubscription == null &&
               _ObservableSource != null && 
               _ObserverSubscriptions.Count > 0)
            {
                _SourceSubscription = _ObservableSource.Subscribe(_Subject);
            }
        }
        private void UnsubscribeObserver(IObserver<T> observer)
        {
            _ObserverSubscriptions[observer].Dispose();
            _ObserverSubscriptions.Remove(observer);
            if(_ObserverSubscriptions.Count == 0)
            {
                _SourceSubscription.Dispose();
                _SourceSubscription = null;
            }
        }
    }
