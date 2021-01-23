    public class SaveListener : NHibernate.Event.ISaveOrUpdateEventListener
    {
        public void OnSaveOrUpdate(NHibernate.Event.SaveOrUpdateEvent e)
        {
            NHibernate.Persister.Entity.IEntityPersister p = e.Session.GetEntityPersister(null, e.Entity);
            if (p.IsVersioned)
            {
                //TODO: check types etc...
                DateTime oldversion = (DateTime) p.GetVersion(e.Entity, e.Session.EntityMode);
                DateTime currversion = (DateTime) p.GetCurrentVersion(e.Entity, e.Session);
                if (oldversion < currversion.AddMinutes(-30))
                    throw new StaleObjectStateException(e.EntityName, e.Entry.Id);
            }
        }
