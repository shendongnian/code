    class Program
    	{
    		static void Main(string[] args)
    		{
    			B x = new B();
    			x.Method();
    		}
    	}
    
    	public static class Ext
    	{
    		public static T Method<T>(this T obj)
    			where T : A,new()
    		{
    			return new T();
    		}
    	}
    
    	public class A
    	{
    	}
    
    	public class B : A
    	{
    		
    	}
