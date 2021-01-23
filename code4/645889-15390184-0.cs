    public class MyObservable<T> : IObservable<T>
    {
        private static object _subscriberSync = new object();
        private IObservable<T> _source;
        
        public MyObservable(IObservable<T> source)
        {
            _source = source;
        }
        
        protected virtual bool OnSubscribing(IObserver<T> obs)
        {
            return false;
        }
        
        public void DohSubscriptionFailed()
        {
            // Whatever the heck you want to do here?
            Console.WriteLine("Sorry, you never got a subscription");
        }
        
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException("observer");
            }
        
            lock (_subscriberSync)
            {
                var accepted = OnSubscribing(observer);   // <------ policy can be applied here
        
                if (!accepted)
                {
                    return Disposable.Create(() => DohSubscriptionFailed());
                }
        
                // ... perform actual subscription went here
                return _source.Subscribe(observer);
            }
        }
    }
