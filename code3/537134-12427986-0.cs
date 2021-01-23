    public class UserFinder
    {
    	private SomeDbContext _dbContext;
    	
    	public UserFinder(SomeDbContext dbContext)
    	{ _dbContext = dbContext }
    	
    	public User FindUser(string name)
    	{ _dbContext.Find<User>(new FindUserByNameQuery(_dbContext, name)); }
    }
