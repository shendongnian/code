    public class HandlerCollection : IEnumerable
    {
        private readonly List<object> _handlers = new List<object>();
        public void Add<TEvent>(IEventHandler<TEvent> handler)
            where TEvent : IEvent
        {
            _handlers.Add(handler);
        }
        public IEventHandler<TEvent> Find<TEvent>()
            where TEvent : IEvent
        {
            return _handlers
                .OfType<IEventHandler<TEvent>>()
                .FirstOrDefault();
        }
        public IEventHandler<TEvent> Find<TEvent>(Func<IEventHandler<TEvent>, bool> predicate)
            where TEvent : IEvent
        {
            return _handlers
                .OfType<IEventHandler<TEvent>>()
                .Where(predicate)
                .FirstOrDefault();
        }
        // Collection initializers can only be applied to types implementing IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _handlers.GetEnumerator();
        }
    }
