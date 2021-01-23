        public class CustomSaveEventListener : DefaultSaveEventListener
    {
        
        protected override object PerformSave(object entity, object id, IEntityPersister persister, bool useIdentityColumn, object anything, IEventSource source, bool requiresImmediateIdAccess)
        {
            ((AuditBase)entity).RowVersion = 0;
            object obj = base.PerformSave(entity, id, persister, useIdentityColumn, anything, source, requiresImmediateIdAccess); 
    return obj;
            }
        }
