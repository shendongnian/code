	public class Parent3
	{
		public Parent3(object i)
		{
			Console.WriteLine("Parent3 ctor()");
			if (i != null)
			{
				Console.WriteLine("Parent3 ctor(int)");
			}
		}
	}
	public class Child3 : Parent3
	{
		public Child3(object i)
			: base(i)
		{
			Console.WriteLine("Child3 ctor()");
			if (i != null)
			{
				Console.WriteLine("Child3 ctor(int)");
			}
		}
	}
