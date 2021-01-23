    var result = db.Scores.Where(s => s.IDNews == IDNews)
                          .Where(s => news.NewsToPoliticians.Contains(s.IDPolitician))
                          .GroupBy(s => new
                                        {
                                          s.IDPolitician,
                                          s.IDAttribute
                                        },
                                    (k,g ) => new
                                              {
                                               k.IDPolitician,
                                               k.IDAttribute,
                                               Sum = g.Sum(x => x.Score)
                                               })
                          .ToLookup(anon => anon.IDPolitician,
                                    anon => new { anon.IDAttribute, anon.Sum })
