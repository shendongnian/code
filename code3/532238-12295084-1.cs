    foreach (var newTag in tagarray.Select(t => 
                   new Tag { Tag1 = t }).Except(db.Tags))
    {
        db.Tags.AddObject(newTag);
    }
    
    try
    {
        db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
    }
    catch (OptimisitcConcurrencyException)
    {
        db.Refresh(RefreshMode.StoreWins, db.Tags);
        foreach (var newTag in tagarray.Select(t => 
                       new Tag { Tag1 = t }).Except(db.Tags))
        {
            db.Tags.AddObject(newTag);
        }
        db.SaveChanges();
    }
           
