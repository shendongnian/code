	public class DefaultPersistEventListener : AbstractSaveEventListener, IPersistEventListener
	{
        //..
		public virtual void OnPersist(PersistEvent @event, IDictionary createdAlready)
		{
            //... 
			EntityState entityState = GetEntityState(entity, @event.EntityName, source.PersistenceContext.GetEntry(entity), source);
			switch (entityState)
			{
				case EntityState.Persistent:
					EntityIsPersistent(@event, createdAlready);
					break;
				case EntityState.Transient:
					EntityIsTransient(@event, createdAlready);
					break;
				case EntityState.Detached:
					throw new PersistentObjectException("detached entity passed to persist: " + GetLoggableName(@event.EntityName, entity));
				default:
					throw new ObjectDeletedException("deleted instance passed to merge", null, GetLoggableName(@event.EntityName, entity));
			}
    }
