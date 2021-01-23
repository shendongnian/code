    foreach(Entity entity in entities)
    {
         var entry = c.Entry(entity);
         if (entry.State == EntityState.Detached)
         {
             c.Entities.Add(entry);
         }
    }
