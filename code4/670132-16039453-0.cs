    class Account
    {
    	public string username { get; set; }
    	public string password { get; set; }
    
    	public Account(string username, string password)
    	{
    		this.username = username;
    		this.password = password;
    	}
    }
    
    class AccountManager
    {
    	Account acc = null;
    
    	public AccountManager(string username, string password)
    	{
    		if(acc == null)
    		{
    			acc = new Account(username, password);
    		}
    	}
    	
    	public Account GetAccountInfo()
    	{
    		return acc;
    	}
    }
