    public class MyBaseClass
    {
    	public MyBaseClass()
    	{
    		Console.WriteLine("MyBaseClass Parameterless");
    	}
    
    	public MyBaseClass(string message)
    	{
    		Console.WriteLine("MyBaseClass Message: " + message);
    	}
    }
    
    public class MySubClass
    {
    	public MySubClass()
    	{
    		Console.WriteLine("MySubClass Parameterless");
    	}
    
    	public MySubClass(string message)
    		: base(message)
    	{
    		Console.WriteLine("MySubClass Message: " + message);
    	}
    
    	public MySubClass(bool someUselessFlag)
    		: this()
    	{
    		Console.WriteLine("MySubClass bool someUselessFlag constructor");
    	}
    }
