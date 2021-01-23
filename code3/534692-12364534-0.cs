    var grouped = ProductCatList.GroupBy(g => g.ProductCategory )
                     .Select(g => new ProductCatGroup()
                                  {
                                      ProductCategory = g.Key,
                                      ProductList = g.Select(p =>  p.productId)
                                                     .ToList()
                                  });
