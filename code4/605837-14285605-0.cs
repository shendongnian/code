    public class MyClass
    {
          private IGeoPositionWatcher<GeoCoordinate> _geoCoordinateWatcher;
    
          /// <summary>
            /// Gets the geo coordinate watcher.
            /// </summary>
            private IGeoPositionWatcher<GeoCoordinate> GeoCoordinateWatcher
            {
                get
                {
                    if (_geoCoordinateWatcher == null)
                    {
                        _geoCoordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                        ((GeoCoordinateWatcher)_geoCoordinateWatcher).MovementThreshold = 3;
                    }
                    return _geoCoordinateWatcher;
                }
            }
    }
