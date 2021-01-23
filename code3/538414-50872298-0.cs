        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("ColumnName") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("ColumnName").CurrentValue = "DefaultValue";
                }
            }
