    var categories = _db.Categories.Select(x => new { 
        ID = x.ID,                                    // This select is done in DB
        Name = x.Name,
        ItemCount = x.Items.Count
    })
    .AsEnumerable()                                   // Get result to LINQ to Objects                                   
    .Select(x => new {                 
        ID = x.ID,                                    // This select is done in memory.
        Breadcrumbs = Infrastructure.CategoryHelpers.Breadcrumbs(x.ID, -1, ""),
        Name = x.Name,
        ItemCount = x.Items.Count
    });
