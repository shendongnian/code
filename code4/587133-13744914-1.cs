    List<Product> products = GetAllProducts();
    var groupedProducts = products.Groupby(p => new { p.ProductionDate, p.CategoryId })  
                              .ToDictionary(
                                   x => x.Key.CategoryId,
                                   x => new Data()
                                         { 
                                             xValue = x.key.ProductionDate.ToString(),
                                             yValue = x.Count().ToString()
                                         }); 
                                  
