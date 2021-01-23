    class ObserverMap<T> : IObserver<T>
    {
        ObserverMap(Action<Exception> onError, Action onCompleted)
        {
            _onError = onError;
            _onCompleted = onCompleted;
            _handlers = new Dictionary<T, List<Action<T>>>();
        }
        ObserverMap(Action<Exception> onError, Action onCompleted, IEqualityComparer<T> comparer) 
        {
            _onError = onError;
            _onCompleted = onCompleted;
            _handlers = new Dictionary<T, List<Action<T>>>(comparer);
        }
        int _stopped;
        Dictionary<T, List<Action<T>>> _handlers;
        Action<Exception> _onError;
        Action _onCompleted;
        public void OnCompleted()
        {
            if (System.Threading.Interlocked.Exchange(ref _stopped, 1) == 0)
            {
                if (_onCompleted != null) _onCompleted();
            }
        }
        public void OnError(Exception error)
        {
            if (System.Threading.Interlocked.Exchange(ref _stopped, 1) == 0)
            {
                if (_onCompleted != null) _onCompleted();
            }
        }
        public void OnNext(T value)
        {
            if (_stopped != 0) return;
            List<Action<T>> match;
            if (_handlers.TryGetValue(value, out match))
            {
                foreach (var handler in match)
                {
                    handler(value);
                }
            }
        }
        public IDisposable RegisterHandler(T key, Action<T> handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            List<Action<T>> match;
            if (!_handlers.TryGetValue(key, out match))
            {
                match = new List<Action<T>>();
                _handlers.Add(key, match);
            }
            match.Add(handler);
            return System.Reactive.Disposables.Disposable.Create(() => match.Remove(handler));
        }
    }
