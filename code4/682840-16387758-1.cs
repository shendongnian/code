    public class DomainEventPublisher
    {
        private List<IDomainEventSubscriber> subscribers;
        public void Subscribe<T>(DomainEventSubscriber<T> subscriber)
            where T : DomainEvent
        {
            if (!this.Publishing)
            {
                this.subscribers.Add((IDomainEventSubscriber)eventSubscriber);
            }
        }
    }
