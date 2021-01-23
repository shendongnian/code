    private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
    {
        // add actual values
        _markers.Add(new RunMarker { Kilometers = 0, Pace = TimeSpan.FromSeconds(1), Calories = 50 });
    }
