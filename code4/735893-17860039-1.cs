    var coord = new GeoCoordinate(loc.Latitude, loc.Longitude);
                    var nearest = ctx.Locations
                        .Select(x => new LocationResult {
                            location = x,
                            coord = new GeoCoordinate { Latitude = x.Latitude?? 0, Longitude = x.Longitude ?? 0 }
                        })
                        .OrderBy(x => x.coord.GetDistanceTo(coord))
                        .First();
    
                    return nearest.location.Id; 
