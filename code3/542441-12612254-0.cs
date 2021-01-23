	using System;
	using System.Text;
	namespace A
	{
		public interface IA
		{
			void A();
			void B();
		}
		public class A
		{
			public IA a;
			public A(IA _a)
			{
				a = _a;
			}
			public void callA()
			{
				Console.WriteLine("callA called, calling A.");
				a.A();
			}
			public void callB()
			{
				Console.WriteLine("callB called, calling B.");
				a.B();
			}
		}
	}
