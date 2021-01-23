    public interface IFoo
    {
    	void Method1();
    
    	void Method2();
    }
    
    public abstract class BaseClass : IFoo
    {
    	public void Method1()
    	{
    		// Common stuff for all BaseClassX classes
    	}
    
        // Abstract method: it ensures IFoo is fully implemented
        // by all classes that inherit from BaseClass, but doesn't provide
        // any implementation right here.
    	public abstract void Method2();
    }
    
    public class MyClass1 : BaseClass
    {
    	public override void Method2()
    	{
    		// Specific stuff for MyClass1
    		Console.WriteLine("Class1");
    	}
    }
    
    public class MyClass2 : BaseClass
    {
    	public override void Method2()
    	{
    		// Specific stuff for MyClass2
    		Console.WriteLine("Class2");
    	}
    }
    
    private static void Main(string[] args)
    {
    	IFoo test1 = new MyClass1();
    	IFoo test2 = new MyClass2();
    
    	test1.Method2();
    	test2.Method2();
    
    	Console.ReadKey();
    }
