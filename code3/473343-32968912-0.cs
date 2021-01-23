	public class ClassA
	{
		public ClassA()
		{
			Construct();
		}
		public virtual void Construct()
		{
			Console.WriteLine("3");
		}
	}
	public class ClassB : ClassA
	{
		public override void Construct()
		{
			Console.WriteLine("2");
			base.Construct();
		}
	}
	public class ClassC : ClassB
	{
		public override void Construct()
		{
			Console.WriteLine("1");
			base.Construct();
		}
	}
