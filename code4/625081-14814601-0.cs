    // System.Data.Objects.EntityEntry
    internal void Detach()
        {
        base.ValidateState();
        bool flag = false;
        RelationshipManager relationshipManager = this._wrappedEntity.RelationshipManager;
        flag = (base.State != EntityState.Added && this.IsOneEndOfSomeRelationship());
        this._cache.TransactionManager.BeginDetaching();
        try
            {
            relationshipManager.DetachEntityFromRelationships(base.State);
            }
        finally
            {
            this._cache.TransactionManager.EndDetaching();
            }
        this.DetachRelationshipsEntries(relationshipManager);
        IEntityWrapper wrappedEntity = this._wrappedEntity;
        EntityKey entityKey = this._entityKey;
        EntityState state = base.State;
        if (flag)
            {
            this.DegradeEntry();
            }
        else
            {
            this._wrappedEntity.ObjectStateEntry = null;
            this._cache.ChangeState(this, base.State, EntityState.Detached);
            }
        if (state != EntityState.Added)
            {
            wrappedEntity.EntityKey = entityKey;
            }
        }
