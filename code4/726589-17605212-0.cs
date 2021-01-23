	public class Class1
	{
		internal Class1() 
		{
		}
	
		public string Foo1() { return "Hello World!"; }
	}
	public class Class2
	{
		Class1 class1 = new Class1();
		public Class1 Class1_Test 
		{
		   get { return class1; }
		}
	}
