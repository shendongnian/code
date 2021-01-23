    var results = orders.GroupBy(order => order.Currency)
                        .SelectMany(g => g.Select((order, index) => new { Index = index, Order = order })
                                          .GroupBy(x => x.Index / MaxListSize)
                                          .Select(g => new OrderGroup() 
                                          {
                                             ListIndex = g.Key,
                                             OrderList = g.Select(x => x.Order).ToList())
                                           })
                                          .ToList())
                        .ToList();
