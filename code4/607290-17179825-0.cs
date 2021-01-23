    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;
    
    public class CustomBasicAuthProvider : BasicAuthProvider
    {
    	public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
    	{
    		// here, you can get the user data from your database instead
    		if (userName == "MyUser" && password == "123")
    		{
    			return true;
    		}
    
    		return false;
    	}
    }
