    var groupResults = _db.SwimGroups
            .ToList() //evaluate the query, bring it into memory
            .Where(g => g.Name.ContainsAny(QueryTerms)) 
            .OrderByDescending(g => g.Name.StartsWithAny(QueryTerms) ? 1 : 0)
            .ThenBy( g => g)
            .Select(g => new { name = g.Name, id = g.ID });
