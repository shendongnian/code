    public void RejectChanges()
    {
        RejectScalarChanges();
        RejectNavigationChanges();
    }
    
    private void RejectScalarChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
    
    private void RejectNavigationChanges()
    {
        var objectContext = ((IObjectContextAdapter)this).ObjectContext;
        var deletedRelationships = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).Where(e => e.IsRelationship && !this.RelationshipContainsKeyEntry(e));
        var addedRelationships = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(e => e.IsRelationship);
    
        foreach (var relationship in addedRelationships)
            relationship.Delete();
    
        foreach (var relationship in deletedRelationships)
            relationship.ChangeState(EntityState.Unchanged);
    }
    
    private bool RelationshipContainsKeyEntry(System.Data.Entity.Core.Objects.ObjectStateEntry stateEntry)
    {
        //prevent exception: "Cannot change state of a relationship if one of the ends of the relationship is a KeyEntry"
        //I haven't been able to find the conditions under which this happens, but it sometimes does.
    	var objectContext = ((IObjectContextAdapter)this).ObjectContext;
    	var keys = new[] { stateEntry.OriginalValues[0], stateEntry.OriginalValues[1] };
    	return keys.Any(key => objectContext.ObjectStateManager.GetObjectStateEntry(key).Entity == null);
    }
