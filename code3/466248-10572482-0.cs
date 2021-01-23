    public interface IEntity
    {
        Guid Id { get; }
    }
    
    private void SaveObject<T>(T entityToSave, DbSet<T> dbSet) where T : class, IEntity
        {
            if (db.Entry(entityToSave).State == EntityState.Detached)
            {
                if (entityToSave.Id == Guid.Empty) // how do I access the Id property?
                    dbSet.Add(entityToSave);
                else
                    db.Entry(entityToSave).State = EntityState.Modified;
            }
        } 
