    public class WebSessionValueProvider: ISessionValueProvider {
    	private const string CURRENTUSERKEY = "CurrentUser"; // TODO: Change this if necessary
    	public string CurrentUser {
    		get { return (string)HttpContext.Current.Session[CURRENTUSERKEY]; }
    		set { HttpContext.Current.Session[CURRENTUSERKEY] = value; }
    	}
    	
    	// Etc for the other props
    }
