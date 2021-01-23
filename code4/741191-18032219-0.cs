    var q = db.Products.Include("Category").ToList();
    q.Load(); // -> you can't!
    // ------------
    db.Products.Include("Category").Load(); // It's OK!
    // This will NOT query the database, just looks in-memory data.
    var p = db.Products.Local.Single(id); 
    // ------------
    var q = db.Products.Include("Category").ToList();
    q.AsQueryable().Load(); // -> It's OK!
    // This also will NOT query the database, just looks in-memory data.
    var p = db.Products.Local.Single(id); 
