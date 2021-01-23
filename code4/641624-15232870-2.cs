    public class User : IEquatable<User>
    {
    	public User(string name, string password)
    	{
    		Name = name;
    		Password = password;
    	}
    
        public string Name { get; set; }
        public string Password { get; set; }
            
        public bool Equals(User other)
        {
            if (other == null) return false;
    
            return other.Name == Name && other.Password == Password;
        }
    }
    
    public class AuthenticationManager
    {
    	private List<User> LoggedInUsers = new List<User>
    	{ new User("Admin", "admin"), new User ("user1", "123"), new User ("user2", "789") };
    
    	public bool Authenticate(string userName, string password)
    	{
    		var user = new User(userName, password);
    		
            //if the user is in the list it will return false otherwise true.
    		return !LoggedInUsers.Any(u => user.Equals(user)); 
    	}
    	
    	public void Login(string name, string password)
    	{
    		LoggedInUsers.Add(new User(name, password));
    	}
    	
    	public void Logout(string name, string password)
    	{
    		LoggedInUsers.Remove(new User(name, password));
    	}
    }
