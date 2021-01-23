        public class Parent
	{
		public Parent()
		{
			Console.WriteLine("Parent ctor()");
		}
		public Parent(int i)
		{
			Console.WriteLine("Parent ctor(int)");
		}
	}
	public class Child : Parent
	{
		private static int _i; //this is likely to blow up at some point.
		public Child() : base(_i)
		{
			Console.WriteLine("Child ctor()");
		}
		public Child(int i) : this()
		{
			_i = i;
			Console.WriteLine("Child ctor(int)");
		}
	}
