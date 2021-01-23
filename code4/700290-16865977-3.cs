    IEnumerable<Item> = items.Select(item => new { Item = item, SubItems = item.SubItems.Where(sub => sub.ID = 1) })
                             .ToList()
                             .Select(row => 
                                             { 
                                                 var item = row.Item;
                                                 item.SubItems = row.SubItems;
                                                 return item;
                                             });
