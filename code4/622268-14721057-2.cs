    if(!this.Set<TEntity>().Local.Any(d=>d.Id == entity.Id))
        {
            this.Set<TEntity>().Attach(entity);
        }
        this.Set<TEntity>().Remove(entity);
