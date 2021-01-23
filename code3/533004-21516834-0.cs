     public virtual TEntity DetachEntity(TEntity entityToDetach)
        {
            if (entityToDetach != null)
                context.Entry(entityToDetach).State = EntityState.Detached;
            context.SaveChanges();
            return entityToDetach;
        }
