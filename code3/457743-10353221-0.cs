                public TEntity Save(TEntity entity)
                {
                    ...    
                    
                    Entities.Set<TEntity>().Add(entity);        
                    Entities.SaveChanges();
                    ...
                }
