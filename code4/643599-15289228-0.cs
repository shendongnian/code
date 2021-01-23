    var list2 = list1.GroupBy(x => x.Name).Select(g => new DocumentInfo()
                                          {
                                              Name = g.Key,
                                              DocCount = g.Sum(x => x.DocCount)
                                          });
