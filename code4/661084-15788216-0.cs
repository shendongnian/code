    public static object returnFullSelectWithCoordinates(IQueryable<RouteQueryModel> r)
    {
        var results = r.Select(b => new
        {
            route_id = b.b.route_id,
            name = b.b.name,
            description = b.b.description,
            distance = b.b.distance,
            distance_to_route = (int)b.distance_to_from_me,
            departure_place = b.b.departure_place,
            arrival_place = b.b.arrival_place,
            owner = b.b.user.username,
            average_rating = b.avg_rating,
            is_favorite = b.is_favorite,
            date = b.b.date,
            attributes = b.b.route_attributes
                         .Select(c => c.route_attribute_types.attribute_name),
            coordinates = b.b.coordinates.Select(c => new coordinateToSend 
                                                      { sequence = c.sequence,
                                                        lat = c.position.Latitude, 
                                                        lon = c.position.Longitude
                                                      })
        }).ToList(); // ToList !!
        int totalCoordinateCount = 0;
        foreach (var x in results)
        {
            if (totalCoordinateCount + x.coordinates.Count
                                     > DataValues.AmountOfCoordinates)
            {
                x.coordinates.Clear();
            }
            else
            {
                totalCoordinateCount += x.coordinates.Count;
            }
        }
        return results;
    }
