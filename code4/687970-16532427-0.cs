    public interface IDomainEventHandler {
        void HandleEvent(object domainEvent);
        bool CanHandleEvent(object domainEvent);
    }
    public abstract class DomainEventHandlerBase<T> : IDomainEventHandler {
        public abstract void HandleEvent(T domainEvent);
        public abstract bool CanHandleEvent(T domainEvent);
        void IDomainEventHandler.HandleEvent(object domainEvent) {
            return HandleEvent((T)domainEvent);
        }
        bool IDomainEventHandler.CanHandleEvent(object domainEvent) {            
            return (domainEvent is T) && CanHandleEvent((T)domainEvent);
        }
    }
