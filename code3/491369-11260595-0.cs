    private static readonly object MappingLock = new object();
    private static bool _ready = false;
    
    public static bool IsMappingInitialised()
    {
        if (!_ready)
        {
            lock (MappingLock)
            {
                if (!_ready)
                {
                    Mapper.CreateMap<ServerWidget, Widget>();
                    _ready = true;
                }
            }
        }
    
        return _ready;
    }
