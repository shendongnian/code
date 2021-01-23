	internal class Program
	{
		private static void Main(string[] args)
		{
			Program.Test1();
			Program.Test2();
		}
		public static void Test1()
		{
			Action a = delegate
			{
				Console.WriteLine("A");
			};
			Action b = delegate
			{
				Console.WriteLine("B");
			};
			Action c = (Action)Delegate.Combine(a, b);
			c();
		}
		public static void Test2()
		{
			Action a = delegate
			{
				Console.WriteLine("A");
			};
			Action b = delegate
			{
				Console.WriteLine("B");
			};
			Action c = (Action)Delegate.Combine(a, b);
			c();
		}
	}
