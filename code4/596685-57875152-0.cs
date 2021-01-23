    class Foo
    {
    	//Stateful field
    	public int x;
    	
    	//Constructor
    	public Foo()
    	{
    		x = 6;	
    	}
    }
    					
    public class Program
    {
    	public static void Main()
    	{
    		var foo = new Foo();
    		foo.x = 8;
    		
    		VarTestField(foo);		
    		Console.WriteLine(foo.x);
    		
    		RefTestField(ref foo);
    		Console.WriteLine(foo.x);		
    	}	
    	
        //Object passed by reference, pointer passed by value
    	static void VarTestField(Foo whatever){
                
    		whatever = new Foo();
    	}
    	//Object passed by reference, pointer passed by reference
    	static void RefTestField(ref Foo whatever){
    		whatever = new Foo();
    	}
    }
