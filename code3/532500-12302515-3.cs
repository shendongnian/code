    var ordersAndPrices =
     allOrders
       .Where(order => !order.Processed)
       .Select(order => new {
                         order, 
                         isDiscounted = order
                           .ProductsInOrder
                           .Any(pio => pio.TheProduct.UnitPrice >= 100M 
                                       && pio.Quantity >= 5)
                        })
       .Select(x => new {
                      order = x.order, 
                      price = x.order
                               .ProductsInOrder
                               .Sum(p=> p.Quantity 
                                        * p.TheProduct.UnitPrice
                                        * (x.isDiscounted ? 0.9M : 1M))});
    
