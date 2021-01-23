    var table = from order in orders
                from item in order.Items.DefaultIfEmpty(new OrderItem())
                from subItem in item.SubItems.DefaultIfEmpty(new SubItem())
                select new
                    {
                        OrderCode = order.Code,
                        ItemPrice = item.Price,
                        ItemQuantity = item.Quantity,
                        SubItemQuantity = subItem.Quantity,
                        SubItemUserName = subItem.UserName
                    };
