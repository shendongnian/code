    public class SaveListener : NHibernate.Event.ISaveOrUpdateEventListener
    {
        public void OnSaveOrUpdate(NHibernate.Event.SaveOrUpdateEvent e)
        {
            NHibernate.Persister.Entity.IEntityPersister p = e.Session.GetEntityPersister(null, e.Entity);
            if (p.IsVersioned)
            {
                object version = p.GetVersion(e.Entity, e.Session.EntityMode);
                object currversion = p.GetCurrentVersion(e.Entity, e.Session);
                if (version.Equals(currversion))
                    throw new StaleObjectStateException(e.EntityName, e.Entry.Id);
            }
        }
