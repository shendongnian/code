    class InMemoryEventBus : IBus
    {
        private readonly IDictionary<Type, object> _subscribers;
        public InMemoryEventBus()
        {
            _subscribers= new Dictionary<ISubscribe<IEvent>, Type>();
        }
        public void Subscribe<T>(ISubscribe<T> subscriber) where T : IEvent
        {
            _subscribers.Add(typeof(T), subscriber);
        }
        public void Send<T>(IEvent @event) where T : class, IEvent
        {
            object value;
            if (_subscribers.TryGetValue(typeof(T), out value))
            {
                 ISubscriber<T> subscriber = (ISubscriber<T>) value;
                 subscriber.Handle(@event);
            }
        }
    }
 
