    GeoCoordinate coord;    
    GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        watcher.PositionChanged += (s,ea) =>
        {
        coord = new Geocoordinate(ea.Position.Location.Latitude, ea.Position.Location.Longitude);
    
        }
