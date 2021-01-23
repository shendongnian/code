    public interface IEventService
    {
        IEnumerable<Event> GetActive();
    }
     
    public class EventService : IEventService
    {
        private readonly Entities entities;
        public EventService(Entities entities)
        {
            this.entities = entities;
        }
        public IEnumerable<Event> GetActive()
        {
            DateTime now = DateTime.Today;
            return this.entities.Events
                .Where(x => !x.removed)
                .Where(x => x.start_date <= now && x.end_date >= now)
                .AsEnumerable();
        }
    }
