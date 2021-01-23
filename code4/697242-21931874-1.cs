    // Add polygon
    var collection = new GeoCoordinateCollection();
    collection.Add(new GeoCoordinate(0d, 0d));
    collection.Add(new GeoCoordinate(10d, 0d));
    collection.Add(new GeoCoordinate(10d, 10d));
    collection.Add(new GeoCoordinate(0d, 10d));
    collection.Add(new GeoCoordinate(0d, 0d));
    
    var poly = new MapPolygon();
    poly.FillColor = Color.FromArgb(80, 255, 0, 0);
    poly.StrokeColor = Colors.Red;
    poly.StrokeThickness = 15;
    poly.Path = collection;
    Map.MapElements.Add(poly);
    private void Map_OnTap(object sender, GestureEventArgs e)
    {
        //var point = e.GetPosition(Map);
        //var coordinate = Map.ConvertViewportPointToGeoCoordinate(point);
    
        int elements = Map.GetMapElementsAt(point).Count;
        System.Diagnostics.Debug.WriteLine(string.Format("Hit {0} map element(s)", elements));
    }
