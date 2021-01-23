	using System;
	using System.Text;
	using System.Diagnostics;
	namespace B
	{
		public class _B : A.IA
		{
			public A.A a;
			public _B(A.A _a)
			{
				a = _a;
			}
			#region IA Members
			public void A()
			{
				Console.WriteLine("A called, calling callB.");
				a.callB();
			}
			public void B()
			{
				Console.WriteLine("B called.");
				Process.GetCurrentProcess().Kill();
			}
			#endregion
		}
	}
