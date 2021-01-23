    var v = db.GetTable<Country>().Where(country => country.Allowed)
                        .GroupJoin(
                            db.GetTable<Team>(),
                            country => country.Id,
                            team => team.CountryId,
                            (country, teams) => new CountryTeamsInfo
                                                    {
                                                        CountryId = country.Id,
                                                        TeamsTotal = teams.Count(),
                                                        TeamsWithoutOwnerFree = teams.Count(t => t.OwnerId != 0),
                                                    }
                        ).GroupJoin(
                            db.GetTable<Team>().Where(te=>te.OwnerId==0),
                            cti => cti.CountryId,
                            team => team.CountryId,
                            (cti, teams) => new CountryTeamsInfo
                            {
                                CountryId = cti.CountryId,
                                TeamsTotal = cti.TeamsTotal,
                                TeamsWithoutOwnerFree = teams.Count(t => t.OwnerId != 0),
                            }
                        )
                        ;
