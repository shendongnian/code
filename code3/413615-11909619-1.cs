	public interface IFoo
	{
		void Method1();
		void Method2();
	}
	public abstract class BaseClass1
	{
		public void Method1()
		{
			//some implementation
		}
	}
	public class MyClass1 : BaseClass1, IFoo
	{
		public void Method2()
		{
			//some implementation
		}
	}
