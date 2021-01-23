    public class YourClass<T> : IDisposable
    {
        private readonly Stack<Tuple<Subject<T>, RoutedEventReceiver<T>, IDisposable> _handlers;
        private readonly IObservable<T> _stream;
        private readonly IDisposable _streamSubscription;
        public YourClass(IObservable<T> stream)
        {
            _handlers = new Stack<Tuple<Subject<T>, RoutedEventReceiver<T>, IDisposable>();
            _stream = stream;
            _streamSubscription = stream.Subscribe(OnNext, OnError, OnCompleted);
        }
        public void Dispose()
        {
            _streamSubscription.Dispose();
            lock (_handlers)
            {
                foreach (var h in _handlers)
                {
                    h.Item3.Dispose();
                    h.Item1.Dispose();
                }
                _handlers.Clear();
            }
        }
        private void OnNext(T value)
        {
            lock (_handlers)
            {
                for (var h in _handlers)
                {
                    h.Item1.OnNext(value);
                    if (!h.Item2.ShouldForwardEvent(value)) break;
                }
            }
        }
        private void OnError(Exception e)
        {
            lock (_handlers)
            {
                for (var h in _handlers) { h.Item1.OnError(e); }
            }
        }
        private void OnCompleted()
        {
            lock (_handlers)
            {
                for (var h in _handlers) { h.Item1.OnCompleted(); }
            }
        }
        public void Push(RoutedEventReceiver<T> handler)
        {
            lock (_handlers)
            {
                var subject = new Subject<T>;
                _handlers.Push(Tuple.Create(subject, handler, handler.Apply(subject)));
            }
        }
        public RoutedEventReceiver<T> Pop()
        {
            lock (_handlers)
            {
                var handler = _handlers.Pop();
                handler.Item3.Dispose();
                handler.Item1.Dispose();
                return handler.Item2;
            }
        }
    }
