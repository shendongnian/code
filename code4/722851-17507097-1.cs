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
     .Where(t => t.score < 4) // eliminate mismatches
     .OrderBy(t => t.score) // put low scores first
     .Select(t => t.pricing) // if we want to read just the pricing entity, select it
     .FirstOrDefault(); // take the first match, or null if no match was found
