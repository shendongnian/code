        var items = itemList.Where(i => i.WarehouseInfo.Any(w => w.LocnCode  == "A1"))
                            .Select(i => new OrderItem
                                         {
                                             idProduct     = i.idProduct, 
                                             quantity      = i.quantity,
                                             WarehouseInfo = i.WarehouseInfo.Where(w => w.LocnCode.Equals("A1"));
                                                                            .ToList()
                                         }
                                   );
 
