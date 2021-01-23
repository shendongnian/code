            List<MapLocation> locations;
            ReverseGeocodeQuery query = new ReverseGeocodeQuery();
            query.GeoCoordinate = new GeoCoordinate(47.608, -122.337);
            query.QueryCompleted += (s, e) =>
                {
                    if (e.Error == null && e.Result.Count > 0)
                    {
                        locations = e.Result as List<MapLocation>;
                        // Do whatever you want with returned locations. 
                        // e.g. MapAddress address = locations[0].Information.Address;
                    }
                };
            query.QueryAsync();
