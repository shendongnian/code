    var nestedGroupedItems = nestedItems.Select(x => x.GroupBy(y => new {y.Key, y.SubKey })
                                                      .Select(g => new Item {
                                                          Key = g.Key.Key,
                                                          SubKey = g.Key.SubKey,
                                                          Quantity = g.Sum(y => y.Quantity)
                                                      }).ToList()).ToList();
