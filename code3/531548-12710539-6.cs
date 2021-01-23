    public class SaveListener : NHibernate.Event.ISaveOrUpdateEventListener
    {
        public void OnSaveOrUpdate(NHibernate.Event.SaveOrUpdateEvent e)
        {
            NHibernate.Persister.Entity.IEntityPersister p = e.Session.GetEntityPersister(null, e.Entity);
            if (p.IsVersioned)
            {
                //TODO: check types etc...
                MyEntity m = (MyEntity) e.Entity;
                DateTime oldversion = (DateTime) p.GetVersion(m, e.Session.EntityMode);
                DateTime currversion = (DateTime) p.GetCurrentVersion(m.ID, e.Session);
                if (oldversion < currversion.AddMinutes(-30))
                    throw new StaleObjectStateException("MyEntity", m.ID);
            }
        }
