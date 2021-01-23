    public class Program
    {
    	public int[] test;
    
    	public Program()
    	{
    		// Fields initializers are inserted at the beginning
    		// of the class constructor
    		this.test = new int[5];
    		
    		// Calling base constructor
    		base.ctor();
    		
    		// Executing derived class constructor instructions
    		Console.Read();
    	}
    }
