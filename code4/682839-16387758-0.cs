    public interface IDomainEventSubscriber
    {
        void HandleEvent(DomainEvent domainEvent);
        Type SubscribedToEventType();
    }
    public abstract class DomainEventSubscriber<T> : IDomainEventSubscriber
        where T : DomainEvent
    {
        void IDomainEventSubscriber.HandleEvent(DomainEvent domainEvent)
        {
            if (domainEvent.GetType() != SubscribedToEventType())
                throw new ArgumentException("domainEvent");
                
            HandleEvent((T)domainEvent);
        }
        
        public abstract void HandleEvent(T domainEvent);
        
        public Type SubscribedToEventType() { return typeof(T); }
    }
    
