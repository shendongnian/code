    public static class AppRoles
    {
    	public const string Manager     =@"domain\App Manager";
    	public const string Admin       =@"domain\App Admin";
    }
    	
    [Authorize(Roles = AppRoles.Admin)] 
    public class MyAbcController : Controller
    {
    	//code
    }
