	public class SomeOtherClass
	{
		public static void Test(SomeClassBase obj)
		{
			
		}
	}
	public abstract class SomeClassBase
	{
		public SomeClassBase()
		{
			SomeOtherClass.Test(this);
		}
	}
	public class SomeClass : SomeClassBase
	{
		public SomeClass() : base()
		{
			
		}
	}
