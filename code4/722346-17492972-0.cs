    private int Add(T entity)
    {
      Using (BarContect db = new BarContext())
      {
        DbSet dbSet = db.Set<T>();
        dbSet.Add(entity);
        db.SaveChanges(); 
      }
      return entity.PrimaryKeyValue; // this would be the integer value of the id
    }
