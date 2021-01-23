    var groupedItems = items.GroupBy(x => new { x.Key, x.SubKey })
                            .Select(g => new Item {
                                Key = g.Key.Key,
                                SubKey = g.Key.SubKey,
                                Quantity = g.Sum(x => x.Quantity)
                            }).ToList();
