    private void gcw_PositionChanged(GeoPositionChangedEventArgs args)
    {
        // Stop the GeoCoordinateWatcher now that we have the device location. 
        this.gcw.Stop();
        bannerAd.LocationLatitude = e.Position.Location.Latitude;
        bannerAd.LocationLongitude = e.Position.Location.Longitude;
        AdGameComponent.Current.Enabled = true;
    }
