    namespace MyNameSpace
    {
    	public class MyClass
    	{
    		public MyClass(Type optionsClassType)
    		{
    			//A PropertyInfo[0] is returned here
    			var test1 = optionsClassType.GetProperties();
    			//Even using typeof
    			var test2 = typeof(MyClassOptions).GetProperties();
    			//Or BindingFlags
    			var test3 = typeof(MyClassOptions).GetProperties
    (BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
    		}
    	}
    
    	public class MyClassOptions
    	{
    		public int MyProperty { get; set; }
    	}
    }
