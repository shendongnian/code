    GeoCoordinateWatcher watcher;
                    watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High)
                    {
                        MovementThreshold = 20
                    };
                    watcher.PositionChanged += this.watcher_PositionChanged;
                    watcher.Start();
    private void watcher_PositionChanged(object sender,   GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (!e.Position.Location.IsUnknown)
            {
                longitude = e.Position.Location.Longitude;
                latitude = e.Position.Location.Latitude;
            }
    }
