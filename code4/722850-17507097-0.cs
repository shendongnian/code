    IQueryable<Pricing> table = ...
    var matches = table.Where(p => p.SearchGUID = searchGUID);
    var result = matches.Select(p => new
    {
        pricing = p 
        // 0 score if client & county match 
        score = p.ClientGUID == clientGUID && p.LocationGUID == countyGUID 
            ? 0
            // 1 score if just county match
            : p.LocationGUID == countyGUID
                ? 1
                // 2 score if just state match
                : p.LocationGUID == stateGUID
                    ? 2
                    // 3 score if client & location are null
                    : p.ClientGUID == null && p.LocationGUID == null
                        ? 3
                        // 4 score if it missed all conditions
                        : 4
     })
     .Where(t => t.score < 4)
     .OrderBy(t => t.score)
     .Select(t => t.pricing)
     .FirstOrDefault();
