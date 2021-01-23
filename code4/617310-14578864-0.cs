    MKLocalSearchRequest req=new MKLocalSearchRequest
    {
      Region=new MKCoordinateRegion(map.CenterCoordinate, new MKCoordinateSpan(0.05, 0.05)), // ~50km radius
      NaturalLanguageQuery=text,
    };
    
    var localSearch=new MKLocalSearch(req);
    localSearch.Start(delegate(MKLocalSearchResponse response, NSError error)
    {
      if (error==null)
      {
        foreach (var item in response.MapItems)
        {
          var coord=item.IsCurrentLocation?map.UserLocation.Coordinate:item.Placemark.Coordinate;
          map.AddAnnotation(new MKPointAnnotation { Coordinate=coord, Title=item.Name });
        }
      }
      //else show error
    });
