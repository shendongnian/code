		//your interface
		public interface IRealFoo : IFoo
		{
			new int FooValue();
		}
	
		//your base class
		public class MyRealClass : MyClass, IRealFoo
		{
			protected virtual int FooValue()
			{
				return ((IFoo)this).FooValue();
			}
			
			int IRealFoo.FooValue()
			{
				return FooValue();
			}
		}
	
		//your child class
		public class MyRealSubClass : MyRealClass
		{
			protected override int FooValue()
			{
				return base.FooValue() * 2;
			}
		}
	
