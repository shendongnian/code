    public void SetupDbContext(DbContext context)
    {
        (DbContext as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.SavingChanges += delegate(object sender, EventArgs e)
        {
            var modified = context.ChangeTracker.Entries<User>().Where(entry => entry.State == EntityState.Modified);
            foreach (var entry in modified)
            {
                if (entry.Property("Status").IsModified)
                {
                    entry.Entity.DataStatus = DateTime.Now;
                }
            }
        };
    }
