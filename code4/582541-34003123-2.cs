      List<BasicGeoposition> PosList = new List<BasicGeoposition>();
      foreach (var item in punkty)
      {
        PosList.Add(new BasicGeoposition()
        {
          Latitude = item.Position.Latitude,
          Longitude = item.Position.Longitude
        });
      }
      //Example of one point
      //PosList.Add(new BasicGeoposition()
      //{
      //  Latitude = 52.46479093,
      //  Longitude = 16.91743341
      //});
      
      MapPolyline line = new MapPolyline();
      line.StrokeColor = Colors.Red;
      line.StrokeThickness = 5;
      line.Path = new Geopath(PosList);
      myMap.MapElements.Add(line);
      
