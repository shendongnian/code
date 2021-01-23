    context.MyEntities.AddObject(new MyEntity() { Id = 1 });
    var entity = this.context
                     .ObjectStateManager
                     .GetObjectStateEntries(System.Data.EntityState.Added)
                     .Select(e => e.Entity)
                     .OfType<MyEntity>()
                     .Where(e => e.Id == 1)
                     .FirstOrDefault();
