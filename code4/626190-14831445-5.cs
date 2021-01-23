    var table = from order in orders
                from item in order.Items.DefaultIfEmpty()
                from subItem in (item != null ? item.SubItems : Enumerable.Empty<SubItem>()).DefaultIfEmpty()
                select new
                    {
                        OrderCode = order.Code,
                        ItemPrice = item != null ? item.Price.ToString() : "n/a",
                        ItemQuantity = item != null ? item.Quantity.ToString() : "n/a",
                        SubItemQuantity = subItem != null ? subItem.Quantity.ToString() : "n/a",
                        SubItemUserName = subItem != null ? subItem.UserName : "n/a"
                    };
