    class NotifyingCollection<T>
    {
        private ConcurrentQueue<Action<T>> _subscribers = new ConcurrentQueue<Action<T>>();
        private ConcurrentQueue<T> _overflow = new ConcurrentQueue<T>();
        private object _lock = new object();
        public void Add(T item)
        {
            _overflow.Enqueue(item);
            Dispatch();
        }
        private void Dispatch()
        {
            // this lock is needed since we need to atomically dequeue from both queues...
            lock (_lock)
            {
                while (_overflow.Count > 0 && _subscribers.Count > 0)
                {
                    Action<T> callback;
                    T item;
                    var r1 = _overflow.TryDequeue(out item);
                    var r2 = _subscribers.TryDequeue(out callback);
                    Debug.Assert(r1 && r2);
                    callback(item);
                    // or, optionally so that the caller thread's doesn't take too long ...
                    Task.Factory.StartNew(() => callback(item));
                    // but you'll have to consider how exceptions will be handled.
                }
            }
        }
        public void TakeAsync(Action<T> callback)
        {
            _subscribers.Enqueue(callback);
            Dispatch();
        }
    }
