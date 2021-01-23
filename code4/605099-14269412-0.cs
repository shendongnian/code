    private void DrawMapMarkers()
    {
        MyMap.Layers.Clear();
        MapLayer mapLayer = new MapLayer();
         
        // Draw marker for current position
        if (MyCoordinate != null)
        {
            DrawAccuracyRadius(mapLayer);
            DrawMapMarker(MyCoordinate, Colors.Red, mapLayer);
        }
         
        ...
         
        MyMap.Layers.Add(mapLayer);
    }
    
    private void DrawMapMarker(GeoCoordinate coordinate, Color color, MapLayer mapLayer)
    {
        // Create a map marker
        Polygon polygon = new Polygon();
        polygon.Points.Add(new Point(0, 0));
        polygon.Points.Add(new Point(0, 75));
        polygon.Points.Add(new Point(25, 0));
        polygon.Fill = new SolidColorBrush(color);
            
        // Enable marker to be tapped for location information
        polygon.Tag = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
        polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);
    
        // Create a MapOverlay and add marker
        MapOverlay overlay = new MapOverlay();
        overlay.Content = polygon;
        overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
        overlay.PositionOrigin = new Point(0.0, 1.0);
        mapLayer.Add(overlay);
    }
