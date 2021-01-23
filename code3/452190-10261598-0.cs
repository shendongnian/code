    from c in db.GetTable<Country>()
    where c.Allowed
    select new CountryTeamsInfo
    {
        CountryId = c.Id,
        TeamsTotal = db.GetTable<Team>().Count(t => t.CountryId == c.Id && t.Allowed),
        TeamsHasOwner = db.GetTable<Team>().Count(t => t.CountryId == c.Id && t.Allowed && t.OwnerId != 0),
    }
