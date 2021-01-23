    public class TheCheapestPubSubEver
    {    
        private Subject<object> _inner = new Subject<object>();
        
        public IObservable<T> Register<T>()
        {
            return _inner.OfType<T>().Publish().RefCount();
        }
        public void Publish<T>(T message)
        {
            _inner.OnNext(message);
        }
    }
