     if(!NHibernateUtil.IsInitialized(object.Lazy_property) )
{
             //open a session 
            session.SaveorUpdate(object);
            NHibernateUtil.Initialize(object.Lazy_property);
            //close the session
