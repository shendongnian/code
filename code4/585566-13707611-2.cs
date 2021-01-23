    var politicianIds = news.NewsToPoliticians.Select(p => p.IDPolitician).ToList()
    var result = db.Scores.Where(s= > s.IDNews == IDNews)
                          .Where(s => politicianIds.Contains(s.IDPolitician))
                          .GroupBy(p => p.IDPolitician,
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
