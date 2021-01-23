    public class EventRepository : IEventRepository
    {
        private readonly IDbManager _dbManager;
    
        public EventRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }
    
        public virtual IEnumerable<Event> GetAll()
        {
            // Data access code
        }
    }
    
    public class CachedEventRepository : IEventRepository
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly IEventRepository _eventRepo;
    
        public ICacheProvider CacheProvider
        {
            get { return _cacheProvider; }
        }
    
        public CachedEventRepository(IEventRepository eventRepo, ICacheProvider cacheProvider)
        {
            if(eventRepo is CachedEventRepository)
                throw new ArgumentException("eventRepo cannot be of type CachedEventRepository", "eventRepo");
    
            _cacheProvider = cacheProvider;
            _eventRepo = eventRepo;
        }
    
        public IEnumerable<Event> GetAll()
        {
            // Caching logic for this method with a call to _eventRepo.GetAll() if required
        }
    }
