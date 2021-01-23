    public class NhibernateRegistry : Registry
    {
    	public NhibernateRegistry()
    	{
    	   
    	    For<ISessionFactory>()
    		.Singleton()
    		.Add(new NHibernateSessionFactory(<oracle connection string>, "ora.nhibernate.config").SessionFactory)
    		.Named("OracleSF");
    
    	    For<ISession>()
    		.HybridHttpOrThreadLocalScoped()
    		.Add(o => o.GetInstance<ISessionFactory>("OracleSF").OpenSession())
    		.Named("OracleSession");
    
    	    For<ISessionFactory>()
    		.Singleton()
    		.Add(new NHibernateSessionFactory(<ms sql connection string>, "sql.nhibernate.config").SessionFactory)
    		.Named("MsSqlSF");
    
    	    For<ISession>()
    		.HybridHttpOrThreadLocalScoped()
    		.Add(o => o.GetInstance<ISessionFactory>("MsSqlSF").OpenSession())
    		.Named("MsSqlSession");
    	}
    }
