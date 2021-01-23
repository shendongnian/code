    private void ReassociateProxy(ILazyInitializer li, INHibernateProxy proxy)
    {
        if (li.Session != Session)
        {
            IEntityPersister persister = session.Factory.GetEntityPersister(li.EntityName);
            EntityKey key = new EntityKey(li.Identifier, persister, session.EntityMode);
            // any earlier proxy takes precedence
            if (!proxiesByKey.ContainsKey(key))
            {
                proxiesByKey[key] = proxy;
            }
            proxy.HibernateLazyInitializer.Session = Session;
        }
    }
