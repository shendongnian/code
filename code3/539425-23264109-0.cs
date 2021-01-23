      [Export]
    public class MyEventBroker : IMyEventBroker
    {
        [ImportingConstructor]
        public MyEventBroker()
        {
                
        }
        private readonly ConcurrentDictionary<Type, List<Action<CompositeEventArguments>>> _compositeEventHandlers = new ConcurrentDictionary<Type, List<Action<CompositeEventArguments>>>();
        public void Publish<T>(CompositeEventArguments args)
        {
            if (_compositeEventHandlers.ContainsKey(typeof (T)))
            {
                _compositeEventHandlers[typeof(T)].ForEach(subscriber=> { if (subscriber != null) subscriber.Invoke(args); }); //TODO : check for null. QUES - Will we need weak references?????
            }
        }
        public void Subscribe<T>(Action<CompositeEventArguments> handler)
        {
            if (!_compositeEventHandlers.ContainsKey(typeof (T)))
                _compositeEventHandlers[typeof(T)] = new List<Action<CompositeEventArguments>>();
            
            _compositeEventHandlers[typeof (T)].Add(handler);
        }
        public void UnSubscribe<T>(Action<CompositeEventArguments> handler)
        {
            if (_compositeEventHandlers.ContainsKey(typeof (T)))
                _compositeEventHandlers[typeof (T)].Remove(handler);
        }
    }
    public class CompositeEvent<T> where T : CompositeEventArguments
    {
    }
    public class CompositeEventArguments
    {
    }
