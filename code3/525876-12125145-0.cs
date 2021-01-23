    public class User : CreateBase
    {
        public string Name { get; set; }
    
        public static User Create(Action<User> a)
        {
    	    return Create<User>(a); //CALL BASE CLASS GENERIC FUNCTION
        }
    }
