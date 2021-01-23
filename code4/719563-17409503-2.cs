      var predicate = PredicateBuilder.False<Entity>();
    
        if(ClickedAdded)
           predicate = predicate.Or(x=>x.Status == "Added");
        if(ClickedDeleted)
           predicate = predicate.Or(x=>x.Status == "Deleted");
        if(ClickedModified)
           predicate = predicate.Or(x=>x.Status == "Modified");
        
        return masterEntities.AsQueryable().Where(predicate);
