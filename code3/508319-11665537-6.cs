    public class LocationController : Controller
    {
        private ILocationRepository _locationRepository;
    
        public LocationController(ILocationRepository locationRepository)
        {
             _locationRepository = locationRepository;
        }
    }
