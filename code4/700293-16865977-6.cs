    var itemsAndSubItems = items
        .Select(item => new 
            {
                Item = item,
                SubItems = item.SubItems.Where(sub => sub.ID = 1)
            }
        );
