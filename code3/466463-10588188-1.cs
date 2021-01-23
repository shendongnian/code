    foreach (KeyValuePair<string, string> _tenantItem in _contextWrapper.TenantsConnectionStrings)
    {
    
        container.Register(
    	Component.For<ISessionFactory>()
    	    .UsingFactoryMethod(k => k.Resolve<MySessionFactoryBuilder>().BuildSessionFactory(_tenantItem.Value))
    	    .Named(_tenantItem.Key),
    
    	Component.For<ISession>()
    	    .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
    	    .Named(_tenantItem.Key + "-nhsession")
    	    .LifeStyle.Transient
    	    );
    
    }
