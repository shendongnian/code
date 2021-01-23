    public void DeleteEntity<TEntity>(TEntity entity) where TEntity : DbEntity
    {
        _context.Set<TEntity>().Attach(entity); // Attaches entity with state Unchanged
        _context.Set<TEntity>().Remove(entity); // Changes entity state to Deleted
        _context.SaveChanges();
    }
