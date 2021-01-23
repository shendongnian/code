    public class EventDispatcher
    {
        private static IKernel_container;
    
        public static void Setup(IKernel container)
        {
            _container = container;
        }
    
        public static void Dispatch<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (var listener in _container.GetAll<IHandle<T>>())
            {
                listener.Handle(domainEvent);
            }
        }
    }
