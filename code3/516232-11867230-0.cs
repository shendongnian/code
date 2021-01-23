    public class Foo
    {
    	public Foo()
    	{
    		Console.WriteLine("Foo");
    	}
    }
    
    public class Foo2 : Foo
    {
    	public Foo2()
    	{
    		Console.WriteLine("Foo2");
    	}
    }
    
    public class Program
    {
    	private static void Main(string[] args)
    	{
    		Foo2 d = new Foo2();
    
    		Console.ReadKey();
    	}
    }
