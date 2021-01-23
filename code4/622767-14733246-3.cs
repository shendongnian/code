    internal class Program
    {
    	public int[] test;
    
    	public Program()
    	{
    		this.test = new int[5];
    		base.ctor();    // Calling base constructor here
    	}
    
    	private static void Main(string[] args)
    	{
    		Console.Read();
    	}
    }
