    public class EventManager
    {
        List<Subscriber> _subscribers = new List<Subscriber>();
    
        public void Subscribe<T>(IEventHandler<T> subscriber)
        {
            _subscribers.Add(new Subscriber{ EventType = typeof(T), Subscriber = subscriber});
        }
    
        public void Publish<T>(T theEvent)
        {
            foreach (var wrapper in subscribers.Where(x => x == typeof(theEvent)))
            {
                ((IEventHandler<T>)wrapper.Subscriber).Handle(theEvent);
            }
        }
    }
