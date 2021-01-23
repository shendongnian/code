    myMap.Layers.Add(new MapLayer()
     {    
        new MapOverlay()
        {
            GeoCoordinate = new GeoCoordinate(37.795032,-122.394927),
            Content = new Ellipse
            {
                Fill = new SolidColorBrush(Colors.Red),
                Width = 40,
                Height = 40
            }
        }});
