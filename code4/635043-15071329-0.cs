    public virtual List<MyBaseType> GetAll(Type entityType)
    {
       return this.datacontext.Set(entityType)
           .Include(l => l.RelationshipEntity)
           .Cast<MyBaseType>()  // The magic here
           .ToList();
    }
