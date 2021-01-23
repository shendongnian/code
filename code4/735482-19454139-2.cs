		public abstract class RealFoo : MyClass
		{
			public virtual int FooValue()
			{
				return ((IFoo)this).FooValue();
			}
		}
	
		public class MyRealClass : RealFoo 
		{
			public override int FooValue() 
			{
				return base.FooValue();
			}
		}
		
		public class MyRealSubClass : MyRealClass 
		{
			public override int FooValue() 
			{
				return base.FooValue() * 2;
			}
		}
	
		//call it like:
		RealFoo x = new MyRealClass();
		RealFoo y = new MyRealSubClass();
		Console.WriteLine(x.FooValue()); //4
		Console.WriteLine(y.FooValue()); //8
