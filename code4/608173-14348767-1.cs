    var query = v.db.pdx_aparts.Where(v => v.Latitude != null && v.Region == region);
    query = connections == "Connections"
        ? query.Where(v => v.WD_Connect >= 1)
        : query.Where(v => v.WD_Connect == null || v.WD_Connect == 0);
    var places = query.Select(v =>  new
                              {
                                  locName = v.Apartment_complex
                                             .Trim()
                                             .Replace("\"", ""),
                                  latitude = v.Latitude,
                                  longitude = v.Longitude
                              })
                      .Distinct()
                      .ToArray();
