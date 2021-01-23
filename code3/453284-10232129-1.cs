    public class EventRepository : IEventRepository
    {
    private ICacheManager _cacheManager;
    public EventRepository(ICacheManager cacheManager)
    {
        _cacheManager = cacheManager;
    }
        public IEnumerable<Event> GetAll()
        {
            // Data access code here
        }
    }
