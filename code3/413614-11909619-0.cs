	public interface IFoo
	{
		void Method1();
		void Method2();
	}
	public abstract class BaseClass1
	{
		void Method1()
		{
			//some implementation
		}
	}
	public class MyClass1 : BaseClass1, IFoo
	{
		void Method2()
		{
			//some implementation
		}
	}
