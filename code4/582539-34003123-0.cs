      List<BasicGeoposition> PosList = new List<BasicGeoposition>();
      foreach (var item in punkty)
      {
        PosList.Add(new BasicGeoposition()
        {
          Latitude = item.Position.Latitude,
          Longitude = item.Position.Longitude
        });
      }
      line.Path = new Geopath(PosList);
      myMap.MapElements.Add(line);
      
