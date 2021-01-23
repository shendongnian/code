    var list = items.Zip(prices, (item, price) => new { item, price })
                    .Zip(discountPrices, (x, discountPrice) => new { x.item, x.price, discountPrice})
                    .Select(x => new MyNewList
                                 {
                                     Name = x.item.Name,                    
                                     Country = x.item.Country,
                                     Price = x.price,
                                     DiscountPrice = x.discountPrice
                                 })
                    .ToList();
