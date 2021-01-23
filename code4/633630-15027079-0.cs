    void Main()
    {
    	Car c = new Car();
    	c.Test();
    }
    
    public class Car
    {
        
    	public Car()
    	{
    	    User = new User();
    	}
    	
    	public void Test()
    	{
    	    User.Static();  // calls static method
    		User.Instance();   // implies this.User
    	}
    
        public User User { get; set; }
    }
    // Define other methods and classes here
    public class User
    {
       public static void Static()
    	{
    	    Console.WriteLine("Static");
    	}
    	
    	public void Instance()
    	{
    	    Console.WriteLine("Instance");
    	}
    }
