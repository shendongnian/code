     if(!NHibernateUtil.IsInitialized(object.Lazy_property) )
{
             //open a session 
             if (session.Contains(object))
                 session.evict(object);
            Session.SaveorUpdate(object);
            NHibernateUtil.Initialize(object.Lazy_property);
            //close the session
