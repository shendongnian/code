    var profilelst = dbContext.ProspectProfiles
        .Where(p => p.CreateId == currentUser)
        .Select(p => new
        {
            ProspectId = p.ProspectId,
            Live = p.Live,
            Name = p.Name,
            LastOpportunity = p.Opportunities
               .OrderByDescending(o => o.FollowUpDate)
               .Select(o => new
               {
                   ServiceETA = o.ServiceETA,
                   FollowUpDate = o.FollowUpDate
               })
               .FirstOrDefault()
        }
        .OrderByDescending(x => x.LastOpportunity.FollowUpDate)
        .Skip(startIndex)  // can be removed if startIndex is 0
        .Take(endIndex)
        .ToList();
