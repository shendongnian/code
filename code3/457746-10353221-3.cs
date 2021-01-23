     public TEntity Save(TEntity entity)
            {
    
                var dbEntity = Entities.Set<TEntity>().Find(entity.Id);
                if (dbEntity != null)               
                    dbEntity = entity;
                else
                    Entities.Set<TEntity>().Add(entity);
                Entities.SaveChanges();
            }
