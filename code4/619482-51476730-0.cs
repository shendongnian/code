    > public void Add(T entity)
    >         {
    >             entity.Create = DateTime.Now;
    >             db.Set<T>().Attach(entity);  // Add Line 
    >             db.Set<T>().Add(entity);
    >             Save();
    >         }
