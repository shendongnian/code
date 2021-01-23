    	namespace SomeNamespace
	{
		public class ParentClass
		{
			public class NestedClass { }
                        
                	public void SomeMethod()
                	{
                		// This compiles, since nested class is used inside parent class
                		NestedClass nestedClass = new NestedClass();
                	}
		}
		public class AnotherClass
		{
			public AnotherClass()
			{
				// Not compiles since "NestedClass" is defined as nested class
				var nestedClass = new NestedClass();
				// Will compiles
				var nestedClass = new ParentClass.NestedClass();
				// Not compiles since "NestedClass" is defined as nested class
				NestedClass nestedClass = new NestedClass();
				// Will compiles
				ParentClass.NestedClass nestedClass = new ParentClass.NestedClass();
			}
		}
	}
