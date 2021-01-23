    public static class EventHandler<in TEvent> : IEventHandler<TEvent>
        where TEvent : IEvent
    {
        public static readonly List<IEventHandler<TEvent>> Handlers =
            new List<IEventHandler<TEvent>>();
        ...
    }
