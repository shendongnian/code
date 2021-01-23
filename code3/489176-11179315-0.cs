    public interface IUserAdapter
    {
    	IPrincipal GetUserPrincipal();
    	void SetAuthenticationCookie(IUser user);
    	void SignOut();
    }
    
    // my business logic representation of a user
    public interface IUser
    {
    	int Id { get; set; }
    	string Name { get; set; }
    }
    
    public class WebUserAdapter : IUserAdapter
    {
    	public IPrincipal GetUserPrincipal()
    	{
    		return HttpContext.Current.User;
    	}
    
    	public void SetAuthenticationCookie(IUser user)
    	{
    		FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
    	}
    
    	public void SignOut()
    	{
    		FormsAuthentication.SignOut();
    	}
    }
