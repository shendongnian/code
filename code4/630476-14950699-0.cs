    public class Auth : AuthorizeAttribute
    {
    	public int MinLevel { get; set; }
    	
    	public override void OnAuthorization(AuthorizationContext filterContext)
    	{
    		//This is where you will need to determine if the user is authorized based upon the minimum level.
    		base.OnAuthorization(filterContext);
    	}
    }
