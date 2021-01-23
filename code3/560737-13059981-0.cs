    public IEnumerable<DALEntity> Get(params string ID)
    {
       var objectSet = objectContext.CreateObjectSet<YourEntityType>();
       var keyNames = objectSet.EntitySet.ElementType.KeyMembers.First(k => k.Name);
    
       return dbSet.Where(m => ID.Contains((string)m.GetType().GetProperty("keyName").GetValue(m, null));
    }
