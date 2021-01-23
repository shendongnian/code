    public class UsersService
    		{
    			private ISession _Session;
    
    			// Session is injected 
    			public UsersService(ISession session)
    			{
    				_Session = session;
    			}
    
    			public IEnumerable<User> GetAllUsers()
    			{
    				return _Session.QueryOver<User>().List();
    			}
    		}
 
