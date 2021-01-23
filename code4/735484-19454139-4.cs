		public class MySubClass : MyClass
		{
			
		}
	
		public static int RealFooValue(this IFoo foo) 
		{
			var type = foo.GetType();
			
			if (type == typeof(MyClass))
				return foo.FooValue();
			else if (type == typeof(MySubClass))
				return foo.FooValue() * 2; //logic goes here
				
			throw new Exception();
		}
	
