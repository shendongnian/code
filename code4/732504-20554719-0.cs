    // switch off for performance
    DbContext.Configuration.AutodetectChangesEnabled = false;
    
    // load root entities   
    var roots = dbContext.Parents.Where( root => %root_condition%).ToList();
    
    // load entities one level lower
    dbContext.DependentEntities.Where( dependent => dependent.Root%root_condition% && %dependent_condition%).ToList();
    
    // detect changes
    dbContext.ChangeTracker.DetectChanges();
    
    // enable changes detection.
    DbContext.Configuration.AutodetectChangesEnabled = true;
