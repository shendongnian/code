    public override int SaveChanges()
    {
       foreach (var entry in ChangeTracker.Entries()
                 .Where(p => p.State == EntityState.Deleted 
                 && p.Entity is ModelBase))//I do have a base class for entities with a single 
                                           //"ID" property - all my entities derive from this, 
                                           //but you could use ISoftDelete here
        SoftDelete(entry);
        
        return base.SaveChanges();
    }
