    var result = news.NewsToPoliticians
                     .GroupJoin( db.Scores.Where(s= > s.IDNews == IDNews),
                                 p => p.IDPolitician,
                                 s => s.IDPolitician,
                                 (k,g) => new
                                          {
                                            PoliticianId = k,
                                            GroupedVotes = g.GroupBy(s => s.IDAtribute,
                                                                     (id, group) => new
                                                                                    {
                                                                                     Atribute = id,
                                                                                     TotalScore = group.Sum(x => x.Score)
                                                                                     })
                                          })
                     .ToList();
