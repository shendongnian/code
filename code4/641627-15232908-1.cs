    class Myclass
    {
    	static List<UserDTO> users = new List<UserDTO>()
    	{
    		new UserDTO() { UserName= "admin", Password = "admin" } ,
    		new UserDTO() { UserName= "user1", Password = "123" } ,
    		new UserDTO() { UserName= "user2", Password = "789" } ,
    	}
    	
        public static void Check_Method(string u_name, string u_password)
        {
    		if (users.Exists(x => x.UserName == u_name && x.Password == u_password)
    		{
    		       MessageBox.Show("login successful");
    		}
    		else
    		{
    			MessageBox.Show("Badshow");
    		}
        }
        public static void add_user(string name, string password)
        {
    		users.Add(new UserDTO() { UserName= name, Password = password });
        }
    }
