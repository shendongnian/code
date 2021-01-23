    #region Handle Initial Entity State
     
    var existingEntities = context
        .ObjectStateManager
        .GetObjectStateEntries(System.Data.EntityState.Unchanged)
        .Select(x => x.Entity as IObjectWithChangeTracker)
        .Where(x => x != null);
     
    var deletes = entityIndex.AllEntities
                        .Where(x => x.ChangeTracker.State == ObjectState.Deleted)
                        .Union(existingEntities
                                .Where(x => x.ChangeTracker.State == ObjectState.Deleted));
     
    var notDeleted = entityIndex.AllEntities
                        .Where(x => x.ChangeTracker.State != ObjectState.Deleted)
                        .Union(existingEntities
                                .Where(x => x.ChangeTracker.State != ObjectState.Deleted));
       
    foreach (IObjectWithChangeTracker changedEntity in deletes)
    {
        HandleDeletedEntity(context, entityIndex, allRelationships, changedEntity);
    }
       
    foreach (IObjectWithChangeTracker changedEntity in notDeleted)
    {
        HandleEntity(context, entityIndex, allRelationships, changedEntity);
    }
     
    #endregion
