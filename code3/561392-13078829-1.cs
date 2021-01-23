    var query = sellers.SelectMany(s => s.Products.Select(p => new { 
                                                       SellerId = s.Id, 
                                                       Product = p })) // 1
                       .OrderBy(x => x.Product.Price) // 2
                       .ThenBy(x => x.Product.Shipping)
                       .ThenBy(x => x.SellerId)
                       .GroupBy(x => x.Product.Sku) // 3
                       .Select(g => g.First()) // 4
                       .GroupBy(x => x.SellerId) // 5
                       .Select(g => new Seller() {  
                            Id = g.Key,
                            Products = g.Select(x => x.Product).ToList() })
                       .ToList();
