    public override int SaveChanges()
    {
        foreach (DbEntityEntry entity in this.ChangeTracker.Entries)
        {
            if (entity.State == System.Data.EntityState.Modified)
                return;
            // more logic, depending on your needs
        }
        base.SaveChanges();
    }
