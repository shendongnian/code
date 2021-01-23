    public T GetEntityByKey<T>(int key)
    {
      using (DBEntities dbe = new DBEntities())
      {
        return = dbe.StoreTables.Set<T>.Find(new object[] {key});
      }
    }
