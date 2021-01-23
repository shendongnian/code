    public class LocationContainer
    {
        public IWGSLocation InnerLocation { get; private set; }
        public void SetLocation(WGSLocation loc)
        {
            InnerLocation = loc;
        }
    }
    
    private readonly LocationContainer _container = new LocationContainer();
    
    public IWGSLocation Location
    {
        get
        {
            if (_container.InnerLocation == null)
            {
                _container.SetLocation(...);
            } 
            return _container.InnerLocation;
        }
    }
