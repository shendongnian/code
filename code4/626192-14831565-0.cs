    var res = order.Items
                   .SelectMany(i => i.SubItems, (Item, Sub) => new { Item, Sub })
                   .Select(r => new { order.Code, 
                                      r.Item.Price, 
                                      ItemQuantity = r.Item.Quantity, 
                                      SubItemQuantity = r.Sub.Quantity, 
                                      r.Sub.UserName });
