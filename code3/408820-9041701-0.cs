    using (var db = new fsEntities())
    {
       var list = db.Products.Where(x => x.ID == 1).ToList();
       var p = new Product { Description = "New Item", Amount = 14};
    
       db.Attach(p);
    
       list.Add(p);   //the new item EntityState is detached
    }
