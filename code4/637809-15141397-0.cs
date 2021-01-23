	internal class Program
	{
		private static void Main(string[] args)
		{
			Derived d = new Derived();
			d.VirtualMethod();
			((Base) d).VirtualMethod();
			Console.ReadLine();
		}
		private class Base
		{
			public virtual void VirtualMethod()
			{
				Console.WriteLine("Base virtual method");
			}
		}
		private sealed class Derived : Base
		{
			public new void VirtualMethod()
			{
				Console.WriteLine("Overriden method");
			}
		}
	}
