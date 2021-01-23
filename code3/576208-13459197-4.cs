    public static class EventHandler<in TEvent> : IEventHandler<TEvent>
        where TEvent : IEvent
    {
        public static readonly List<TEvent> Handlers = new List<TEvent>();
        ...
    }
