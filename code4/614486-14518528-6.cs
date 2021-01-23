    public class EventManager
    {
        IYourContainer _container;
    
        public EventManager(IYourContainer container)
        {
            _container = container;
        }
    
        public void Publish<T>(T theEvent)
        {
            foreach (var subscriber in _container.ResolveAll<IEventHandler<T>>())
            {
                subscriber.Handle(theEvent);
            }
        }
    }
