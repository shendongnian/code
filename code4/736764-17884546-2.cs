    public interface IEventService
    {
        IEnumerable<Event> All { get; }
        void AddOrUpdateEvent(Event event);
        IEnumerable<Event> GetActive();
        void RemoveEvent(Event event);
    }
