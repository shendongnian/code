    public IEnumerable<DALEntity> Get(params string IDs)
    {
       var objectSet = objectContext.CreateObjectSet<YourEntityType>();
       var keyNames = objectSet.EntitySet.ElementType.KeyMembers.First(k => k.Name);
    
       return dbSet.Where(m => ID.Contains((string)m.GetType().GetProperty(keyNames ).GetValue(m, null));
    }
