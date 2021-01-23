    public static void Upsert<T>(this ObjectContext context, T entity, int key)
      where T : EntityObject
    {
      if (entity != null)
      {
        ObjectSet<T> objectSet = context.CreateObjectSet<T>();
        if (key > 0)
        {
          if (entity.EntityState == EntityState.Detached)
          {
            objectSet.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
          }
        }
        else
        {
          objectSet.AddObject(entity);
        }
      }
    }
