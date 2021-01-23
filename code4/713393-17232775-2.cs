     items
       .GroupBy(x => x.ProductId)
       .Select(g => new MyGroceryListItems{
                          g.Key.ProductId,
                          g.Key.ProductName,
                          g.Sum(gg => gg.Quantity)
                    })
