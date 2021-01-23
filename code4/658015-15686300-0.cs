    var results = shoppingList.GroupBy(s => s.ProductID)
                              .Select(g => new {
                                                   ProductID = g.Key,
                                                   totalQty = g.Sum(I => i.Quantity)
                                               }
                                     );
