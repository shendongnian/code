    public class DomainEvent
    {
    }
    // The 'in' isn't actually needed to make this work, but it can be added anyway:
    public interface IDomainEventSubscriber<in T> where T: DomainEvent
    {
        void HandleEvent(T domainEvent);
        Type SubscribedToEventType();
    }
    public abstract class DomainEventSubscriber<T>: IDomainEventSubscriber<T> where T: DomainEvent
    {
        public abstract void HandleEvent(T domainEvent);
        public Type SubscribedToEventType()
        {
            return typeof(T);
        }
    }
    public class DomainEventPublisher
    {
        private List<DomainEventSubscriber<DomainEvent>> subscribers;
        public void Subscribe<T>(IDomainEventSubscriber<T> subscriber)
            where T: DomainEvent
        {
            DomainEventSubscriber<DomainEvent> eventSubscriber;
            eventSubscriber = (DomainEventSubscriber<DomainEvent>)subscriber;
            if (!this.Publishing)
            {
                this.subscribers.Add(eventSubscriber);
            }
        }
    }
