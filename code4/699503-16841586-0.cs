    (from i in context.Items
     group i by i.RuleId into g
     let item = g.FirstOrDefault(x => x.ItemId == itemId)
     select new
     {
         ItemId = item == null ? null : itemId, // default if not found
         RuleId = g.Key,
         IsActive = item == null ? true : item.IsActive
     })
    .AsEnumerable() // move to memory
    .Select(i => new Item { 
         ItemId = i.ItemId, 
         RuleId = i.RuleId, 
         IsActive = i.IsActive 
    });
