    public class DbContextFactory
    {
    	private ILifetimeScope m_RootLifetimeScope;
    	
    	public DbContextFactory(ILifetimeScope rootLifetimeScope)
    	{
    		m_RootLifetimeScope = rootLifetimeScope;
    	}
    	
    	public IDbContext CreateDbContext()
    	{
    		if (logic for selection first dbcontext)
    		{
    			return m_RootLifetimeScope.ResolveNamed<IDbContext>("first");
    		}
    		else if (logic for selection second dbcontext)
    		{
    			return m_RootLifetimeScope.ResolveNamed<IDbContext>("second");
    		}
    		else 
    		{
    			throw new NotSupportedException();
    		}
    	}
    }
    //registration
    
    builder.RegisterType<DbContextFactory>().SingleInstance();
    
    //using
    
    var factory = yourContainer.Resolve<DbContextFactory>();
    var context = factory.CreateDbContext();
