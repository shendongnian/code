    ...
    using (ISession session = MyNHibernateSession())
    {
         session.Lock(v, LockMode.None);
    
         // somwwhere into these4 lines Vehicle comes Finded
    ...
