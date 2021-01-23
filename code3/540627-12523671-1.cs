    public class User
    {
    	public string UserName { get; set; }
    	public string Password { get; set; }
    }
    
    public void SaveUser(User user)
    {
    	var ser = new XmlSerializer(typeof(User));
    	using(var file = File.OpenWrite(@"c:\myfilepath\user.xml")) 
    	{
    		ser.Serialize(file, user);
    	}
    }
    
    public User GetUser(string xmlFile)
    {
    	var ser = new XmlSerializer(typeof(User));
    	User user;
    	using (var file = File.OpenRead(xmlFile))
    	{
    		user = (User)ser.Deserialize(file);
    	}
    	return user;
    }
