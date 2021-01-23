    public class UsersController : ApiController
    {
    	public List<CMSUser> Get()
    	{
    	    return MyCache.Users;
    	}
    }
