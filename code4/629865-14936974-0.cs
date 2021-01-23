      LocationCollection locationCollection = new LocationCollection ();
      // The Venue class is a custom class, the Latitude & Logitude are of type Double
      foreach (Venue venue _venues)
      {
           Bing.Maps.Location location = new Location(venue.Latitude, venue.Longitude);
           // Place Pushpin on the Map
           Pushpin pushpin = new Pushpin();
           pushpin.RightTapped += pushpin_RightTapped;
           MapLayer.SetPosition(pushpin, location);
           myMap.Children.Add(pushpin);
           locationCollection.Append(location);
      }
      myMap.SetView(new LocationRect(locationCollection));
