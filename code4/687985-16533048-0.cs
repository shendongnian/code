    namespace My.Namespace
    {
    	using H = MyHelperClass;
    
    	public class MyHelperClass
    	{
    		public static void HelperFunc1()
    		{
    			Console.WriteLine("Here's your help!");
    		}
    	}
    
    	public class MyHelperClass2
    	{
    		public static void HelperFunc4()
    		{
    			Console.WriteLine("Here's your help!");
    		}
    	}
    
    	public interface IReallyLongHelperClassName { }
    
    	public static class ReallyLongHelperClassNameExtensions
    	{
    		public static void HelperFunc3(this IReallyLongHelperClassName self)
    		{
    			Console.WriteLine("Here's your help!");
    		}
    	}
    
    	public class MyClass : MyHelperClass2, IReallyLongHelperClassName
    	{
    		private static readonly Action HelperFunc2 = MyHelperClass.HelperFunc1;
    
    		private static void HelperFunc5() 
    		{
    			Console.WriteLine("Here's your help!");
    		}
    
    		public void MyFunction()
    		{
    			//Method 1 use an alias to make your helper class name shorter
    			H.HelperFunc1();
    			//Method 2 use a class property
    			HelperFunc2();
    			//Method 3 extend an interface that has extension methods.
    			//Note: you'll have to use the this keyword when calling extension
    			this.HelperFunc3();
    			//Method 4 you have access to methods on classes that you extend.
    			HelperFunc4();
    			//Method 5 put the helper method in your class
    			HelperFunc5();
    		}
    	}
    }
