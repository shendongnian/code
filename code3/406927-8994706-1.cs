    var results = orders.GroupBy(order => order.Currency)
                        .SelectMany(g => g.Select((order, index) => new { Index = index, Order = order })
                                          .GroupBy(x => x.Index / MaxListSize)
                                          .Select(og => new OrderGroup() 
                                          {
                                             ListIndex = og.Key,
                                             OrderList = og.Select(x => x.Order).ToList()
                                           })
                                          .ToList())
                        .ToList();
