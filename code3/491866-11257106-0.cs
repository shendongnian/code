    protected override void ApplicationStartup(IWindsorContainer container, 
                                               Nancy.Bootstrapper.IPipelines pipelines)
    {
      base.ApplicationStartup(container, pipelines);
      pipelines.BeforeRequest += ctx => CreateSession(container);
      pipelines.AfterRequest += ctx => CommitSession(container);
      pipelines.OnError += (ctx, ex) => RollbackSession(container);
      // Other startup stuff 
    }
    private Response CreateSession(IWindsorContainer container)
    {
      var sessionFactory = container.Resolve<ISessionFactory>();
      var requestSession = sessionFactory.OpenSession();
      CurrentSessionContext.Bind(requestSession);
      requestSession.BeginTransaction();
      return null;
    }
    
    private AfterPipeline CommitSession(IWindsorContainer container)
    {
      var sessionFactory = container.Resolve<ISessionFactory>();
      if (CurrentSessionContext.HasBind(sessionFactory))
      {
        var requestSession = sessionFactory.GetCurrentSession();
        requestSession.Transaction.Commit();
        CurrentSessionContext.Unbind(sessionFactory);
        requestSession.Dispose();
      }
      return null;
     }    
    private Response RollbackSession(IWindsorContainer container)
    {
      var sessionFactory = container.Resolve<ISessionFactory>();
      if (CurrentSessionContext.HasBind(sessionFactory))
      {
        var requestSession = sessionFactory.GetCurrentSession();
        requestSession.Transaction.Rollback();
        CurrentSessionContext.Unbind(sessionFactory);
        requestSession.Dispose();
      }
      return null;
    }
