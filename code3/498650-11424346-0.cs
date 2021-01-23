    private GeoCoordindate _location;
    
    public GeoCoordinate Location
    {
        get
        {
            if (_location == null)
                _location = new GeoCoordinate(Latitude, Longitude);
    
            return _location;
        }
    }
