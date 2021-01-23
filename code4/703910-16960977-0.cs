    public void SaveEntity<TEntity>(TEntity entity) where TEntity : DbEntity
    {
        if (entity.Id.Equals(Guid.Empty))
        {
            _context.Set<TEntity>().Add(entity); // Automatically sets state to Added
        }
        else 
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = System.Data.EntityState.Modified;
        }
        _context.SaveChanges();
    }
