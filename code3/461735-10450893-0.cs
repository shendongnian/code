    foreach (var id in dbContext.MyEntities.Select(e => e.Id))
    {
        var entity = new MyEntity { Id = id };
        dbContext.MyEntities.Attach(entity);
        dbContext.MyEntities.Remove(entity);
    }
    dbContext.SaveChanges();
