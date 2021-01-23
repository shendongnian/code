    // Put these in the domain project
    
    public class EventDispatcher
    {
        private static IEventDispatcher _dispatcher;
    
        public static void Setup(IEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
    
        public static void Dispatch<T>(T domainEvent) where T : IDomainEvent
        {
    		_dispatcher.Dispatch<T>(domainEvent);
        }
    }
    
    public interface IEventDispatcher
    {
        public void Dispatch<T>(T domainEvent) where T : IDomainEvent;
    }
    
    
    // and this one in the project which has Ninject
    
    public class NinjectEventDispatcher : IEventDispatcher
    {
        private static IKernel _container;
    
        public NinjectEventDispatcher(IKernel container)
        {
            _container = container;
        }
    
        public void Dispatch<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (var listener in _container.GetAll<IHandle<T>>())
            {
                listener.Handle(domainEvent);
            }
        }
    }
    
    // And after the container have been configured:
    EventDispatcher.Setup(new NinjectEventDispatcher(_container));
