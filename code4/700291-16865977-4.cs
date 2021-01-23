    IQueryable<Item> items = items.Select(item => new Item 
                                            { 
                                               SubItems = item.SubItems.Where(sub => sub.ID == 1),
                                               OtherProp = item.OtherProp
                                               /*etc for the other properties on Item*/
                                            });
