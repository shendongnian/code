    namespace ConsoleApp
    {
    
    	using ClassOne = Assembly.One.MyClass; /* your dll 1 class */
    	using ClassTwo = Assembly.Two.MyClass; /* your dll 2 class */
    
    	class Program
    	{
    	
    		static void Main(string[] args)
    		{
    
    			ClassOne one = new ClassOne();
    			// Do your stuff with ClassOne object
    
    			ClassTwo two = new ClassTwo();
    			// Do your stuff with ClassTwo object
    			
    		}
    	}
    }
