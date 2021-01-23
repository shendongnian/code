    public class ApplicationDbContext : DbContext
    {
    	public ApplicationDbContext()
    		: base("ConnectionStringName")
    	{
    	}
    
    	// DbSet properties...
    }
