    public ISession OpenSession()
    {
      if(CurrentSessionContext.HasBind(SessionFactory))
      {
         return SessionFactory.GetCurrentSession();
      }
      // else  
      var session = SessionFactory.OpenSession();
      NHibernate.Context.CurrentSessionContext.Bind(session);
      return session;
    }
