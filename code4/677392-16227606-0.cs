    public class UserInfo
    {
    	public string User { get; private set; }
    	public string Pass { get; private set; }
    	public string Location { get; private set; }
    	
    	public UserInfo(string user, string pass, string location)
    	{
    		this.User = user;
    		this.Pass = pass;
    		this.Location = location;
    	}
    }
