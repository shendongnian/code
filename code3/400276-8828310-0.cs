	private class Base
	{
		public virtual void Test()
		{
			Console.WriteLine("Base");
		}
		public virtual void Test2()
		{
			Console.WriteLine("Base");
		}
	}
	private class Derived : Base
	{
		public override void Test()
		{
			Console.WriteLine("Derived");
		}
		public void Test2()
		{
			Console.WriteLine("Derived");
		}
	}
	static void Main()
	{
		Base b = new Base();
		Derived d = new Derived();
		Base dInB = new Derived();
		b.Test();
		d.Test();
		dInB.Test();
		b.Test2();
		d.Test2();
		dInB.Test2();
		Console.ReadKey(true);
	}
