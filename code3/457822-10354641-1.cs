    public partial class Database
    {
      public override int SaveChanges(SaveOptions options)
      {
        foreach(var w in this.ObjectStateManager
                             .GetObjectStateEntries(EntityState.Added)
                             .Where(e => e.Entity is Widget)
                             .Select(e => (Widget)e.Entity))
        {
          if(w.Created == default(DateTime))
            w.Created = DateTime.Now;
        }
    
        return base.SaveChanges(options);
      }
    }
