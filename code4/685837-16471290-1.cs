    var dictionary = 
        db.ProductInventory.GroupBy(x => new { x.Manager, x.Product, x.ExpirationDate })
          .ToDictionary(g => g.Key.Manager,
                        g => g.Select(x => new ProductInventoryCountModel 
                                      {
                                          Product = x.Key.Product,
                                          ExpirationDate = x.Key.ExpirationDate,
                                          Count = x.Count()
                                      }).ToList());
