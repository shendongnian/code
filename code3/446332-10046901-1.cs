    var finalQuery = BoughtItemDB.BoughtItems
                                 .GroupBy(item => item.ItemCategory);
                                 .Select(g => new 
                                  { 
                                      ItemCategory = g.Key, 
                                      Cost = g.Sum(x => x.ItemAmount)
                                  });
