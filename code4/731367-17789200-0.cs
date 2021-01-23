     public static ISession GetSession()
    {
      NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();       
      return config.AddAssembly("Assembly Name").BuildSessionFactory().OpenSession();
    }
