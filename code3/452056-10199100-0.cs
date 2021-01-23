    public class LogonInfo
    {
    	[XmlIgnore]
    	public string Password { get; set; }
    	
    	public string EncPassword {
    	{
    		get
    		{
    			return Encrypt(Password);
    		}
    		set
    		{
    			Password = Decrypt(value);
    		}
    	}
    
    	// TODO: add Encrypt and Decrypt methods
    }
