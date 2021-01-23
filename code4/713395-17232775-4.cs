     items
       .GroupBy(x => x.ProductId)
       .Select(g => new MyGroceryListItems{
                          g.Key.ProductId,
                          g.Key.ProductName,
                          Quantity = g.Sum(gg => gg.Quantity)
                    })
