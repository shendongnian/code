    public class PrioritizedObservable<T> 
       : IObservable<T>, IObserver<T>, IDisposable
    {
        private IObservable<T> _source;
        private ISubject<T,T> _intermediary;
        private IList<Tuple<int, Subject<T>>> _router;
        
        public PrioritizedObservable(IObservable<T> source)
        {
            // Make sure we don't accidentally duplicate subscriptions
            // to the underlying source
            _source = source.Publish().RefCount();
            
            // A proxy from the source to our internal router
            _intermediary = Subject.Create(this, _source);
            _source.Subscribe(_intermediary);        
            
            // Holds per-priority subjects
            _router = new List<Tuple<int, Subject<T>>>();
        }
        
        public void Dispose()
        {
            _intermediary = null;
            foreach(var entry in _router)
            {
                entry.Item2.Dispose();
            }
            _router.Clear();
        }
    
        private ISubject<T,T> GetFirstListener()
        {
            // Fetch the first subject in our router
            // ordered by priority 
            return _router.OrderBy(tup => tup.Item1)
                .Select(tup => tup.Item2)
                .FirstOrDefault();
        }
        
        void IObserver<T>.OnNext(T value)
        {
            // pass along value to first in line
            var nextListener = GetFirstListener();
            if(nextListener != null)
                nextListener.OnNext(value);
        }
        
        void IObserver<T>.OnError(Exception error)
        {
            // pass along error to first in line
            var nextListener = GetFirstListener();
            if(nextListener != null)
                nextListener.OnError(error);
        }
        
        void IObserver<T>.OnCompleted()
        {
            var nextListener = GetFirstListener();
            if(nextListener != null)
                nextListener.OnCompleted();
        }
        
        public IDisposable Subscribe(IObserver<T> obs)
        {
            return PrioritySubscribe(1, obs);
        }
        
        public IDisposable PrioritySubscribe(int priority, IObserver<T> obs)
        {
            var sub = new Subject<T>();
            var subscriber = sub.Subscribe(obs);
            var entry = Tuple.Create(priority, sub);
            _router.Add(entry);
            _intermediary.Subscribe(sub);
            return Disposable.Create(() => 
            {
                subscriber.Dispose();
                _router.Remove(entry);
            });
        }
    }
