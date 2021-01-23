	namespace YourAssembly.Classes
	{
		internal class C1
		{
			public void Foo()
			{
			
			}
		}
		
		public class C2
		{
			public void DoFoo()
			{
				new C1().Foo();		
			}
		}
	}
