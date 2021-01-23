    public SoftDeleteBehavior : IRepositoryBehavior
    {
       // omitted
    
       public bool AppliesToEntityType(Type entityType)
       {
           // check to see if type supports soft deleting
           return true;
       }
    
       public void OnRemoving(CancellableBehaviorContext context)
       {
            var entity = context.Entity as ISoftDeletable;
            entity.Deleted = true; // when the NHibernate session is flushed, the Deleted column will be updated
    
            context.Cancel = true; // set this to true to make sure the repository doesn't physically delete the entity.
       }
    }
