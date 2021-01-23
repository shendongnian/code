    /// <summary> Constructs an event containing the pertinent information. </summary>
    /// <param name="source">The session from which the event originated. </param>
    /// <param name="entity">The entity to be invloved in the database operation. </param>
    /// <param name="id">The entity id to be invloved in the database operation. </param>
    /// <param name="persister">The entity's persister. </param>
    protected AbstractPostDatabaseOperationEvent(
       IEventSource source
     , object entity
     , object id
     , IEntityPersister persister) 
