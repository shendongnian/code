        public class Parent
	{
		public Parent()
		{
			Init();
		}
		protected void Init()
		{
			Console.WriteLine("Parent ctor()");
		}
		public Parent(int i)
		{
			Init(i);
		}
		protected void Init(int i)
		{
			Console.WriteLine("Parent ctor(int)");
		}
	}
	public class Child : Parent
	{
		public Child()
		{
			Init();
		}
		
		protected void Init()
		{
			Console.WriteLine("Child ctor()");
		}
		public Child(int i)
		{
			Init(i);
			base.Init(i);
			Init();
		}
		protected void Init(int i)
		{
			Console.WriteLine("Child ctor(int)");
		}
	}
