    var query = sellers.SelectMany(s => s.Products.Select(p => new { 
                                                     SellerId = s.Id, 
                                                     Product = p }))
                       .OrderBy(x => x.Product.Price)
                       .ThenBy(x => x.Product.Shipping)
                       .ThenBy(x => x.SellerId)
                       .GroupBy(x => x.Product.Sku)
                       .Select(g => g.First())
                       .GroupBy(x => x.SellerId)
                       .Select(g => new Seller() {
                            Id = g.Key,
                            Products = g.Select(x => x.Product).ToList() })
                       .ToList();
