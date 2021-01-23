    public override int SaveChanges()
    {    
        foreach (var entityState in ChangeTracker.Entries())
        {
            // loggin here
        }
        return base.SaveChanges();
    }
