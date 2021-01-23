    var table = from r in db.VenuePostCodes 
                select new {
                    lat = r.Latitude,
                    lng = r.Longitude,
                    name = r.Name,
                    distance = db.udf_Haversine(
                                      r.Latitude,r.Longitude,
                                      r.Latitude,r.Longitude2)
                };
