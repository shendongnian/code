    var result = db.GetTable<Country>()
                   .GroupJoin(db.GetTable<Team>(),
                       c => c.Id,
                       t => t.CountryId,
                       (country, teams) => new
                       {
                           CountryId = country.Id,
                           TeamsTotal = teams.Count(),
                           TeamsWithoutOwnerFree = teams.Count(t => t.OwnerId == 0)
                       })
                   .ToList();
