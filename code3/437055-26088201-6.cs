    /// <summary>
    ///     Truncates the database.
    /// </summary>
    public void TruncateDatabase()
    {
        foreach (
            var set in 
            from p in GetType().GetProperties() 
            where p.PropertyType == typeof (DbSet<IEntity>) 
            select p.GetValue(typeof(DbSet<IEntity>)) as DbSet<IEntity>)
        {
            // Do something with each set.
            set.Truncate();
        }
        SaveChanges();
    }
