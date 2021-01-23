    internal interface IEntityWrapper
    {
    void EnsureCollectionNotNull(RelatedEnd relatedEnd);
    EntityKey GetEntityKeyFromEntity();
    void AttachContext(ObjectContext context, EntitySet entitySet, MergeOption mergeOption);
    void ResetContext(ObjectContext context, EntitySet entitySet, MergeOption mergeOption);
    void DetachContext();
    void SetChangeTracker(IEntityChangeTracker changeTracker);
    void TakeSnapshot(EntityEntry entry);
    void TakeSnapshotOfRelationships(EntityEntry entry);
    void CollectionAdd(RelatedEnd relatedEnd, object value);
    bool CollectionRemove(RelatedEnd relatedEnd, object value);
    object GetNavigationPropertyValue(RelatedEnd relatedEnd);
    void SetNavigationPropertyValue(RelatedEnd relatedEnd, object value);
    void RemoveNavigationPropertyValue(RelatedEnd relatedEnd, object value);
    void SetCurrentValue(EntityEntry entry, StateManagerMemberMetadata member, int ordinal, object target, object value);
    void UpdateCurrentValueRecord(object value, EntityEntry entry);
    RelationshipManager RelationshipManager { get; }
    bool OwnsRelationshipManager { get; }
    object Entity { get; }
    EntityEntry ObjectStateEntry { get; set; }
    EntityKey EntityKey { get; set; }
    ObjectContext Context { get; set; }
    MergeOption MergeOption { get; }
    Type IdentityType { get; }
    bool InitializingProxyRelatedEnds { get; set; }
    bool RequiresRelationshipChangeTracking { get; }
    } 
    /// <summary>
    /// Adds an object to the object context.
    /// </summary>
    /// <param name="entitySetName">Represents the entity set name, which may optionally be qualified by the entity container name. </param><param name="entity">The <see cref="T:System.Object"/> to add.</param><exception cref="T:System.ArgumentNullException">The <paramref name="entity"/> parameter is null. -or-The <paramref name="entitySetName"/> does not qualify.</exception>
    public void AddObject(string entitySetName, object entity)
    {
      EntityUtil.CheckArgumentNull<object>(entity, "entity");
      EntityEntry existingEntry;
      IEntityWrapper wrappedEntity = EntityWrapperFactory.WrapEntityUsingContextGettingEntry(entity, this, out existingEntry);
      if (existingEntry == null)
        this.MetadataWorkspace.ImplicitLoadAssemblyForType(wrappedEntity.IdentityType, (Assembly) null);
      EntitySet entitySet;
      bool isNoOperation;
      this.VerifyRootForAdd(false, entitySetName, wrappedEntity, existingEntry, out entitySet, out isNoOperation);
      if (isNoOperation)
        return;
      System.Data.Objects.Internal.TransactionManager transactionManager = this.ObjectStateManager.TransactionManager;
      transactionManager.BeginAddTracking();
      try
      {
        RelationshipManager relationshipManager = wrappedEntity.RelationshipManager;
        bool flag = true;
        try
        {
          this.AddSingleObject(entitySet, wrappedEntity, "entity");
          flag = false;
        }
        finally
        {
          if (flag && wrappedEntity.Context == this)
          {
            EntityEntry entityEntry = this.ObjectStateManager.FindEntityEntry(wrappedEntity.Entity);
            if (entityEntry != null && entityEntry.EntityKey.IsTemporary)
            {
              relationshipManager.NodeVisited = true;
              RelationshipManager.RemoveRelatedEntitiesFromObjectStateManager(wrappedEntity);
              RelatedEnd.RemoveEntityFromObjectStateManager(wrappedEntity);
            }
          }
        }
        relationshipManager.AddRelatedEntitiesToObjectStateManager(false);
      }
      finally
      {
        transactionManager.EndAddTracking();
      }
    }
