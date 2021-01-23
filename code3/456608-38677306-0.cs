    using (var context = new SomeDBContext())
    {
    
    
    foreach (var item in model.ShopItems)  // ShopItems is a posted list with values 
    {
    
    var feature = context.Shop.Where(h => h.ShopID == 123 && h.Type == item.Type).ToList();
    
    feature.ForEach(a => a.SortOrder = item.SortOrder);
    
    
    context.SaveChanges();
    }
    }
