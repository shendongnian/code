    public static void Raise<TEvent>(TEvent eventToRaise)
        where TEvent : IEvent
    {
        if (eventToRaise == null)
        {
            throw new ArgumentNullException("eventToRaise");
        }
        if (typeof(TEvent) == typeof(IEvent))
        {
            DomainEvents.Raise((dynamic)eventToRaise);
        }
        else
        {
            foreach (IDomainEventHandlerProvider provider in DomainEvents.eventHandlerProviders)
            {
                foreach (IEventHandler<TEvent> handler in provider.GetHandlers<TEvent>())
                {
                    handler.Handle(eventToRaise);
                }
            }
        }
    }
