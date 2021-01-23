    IUnityContainer container = new UnityContainer();
    container.RegisterType<IDbManager, SqlDbManager>();
    container.RegisterType<EventRepository>();
    
    var repo = container.Resolve<EventRepository>();
    
    var data = repo.GetAll();
    
    Assert.IsTrue(data.Count() > 0);
