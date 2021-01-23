	using System;
	namespace VirtualPropertyReflection
	{
		interface I
		{
			int P1 { get; set; }
			int P2 { get; set; }
		}
		class A : I
		{
			public int P1 { get; set; }
			public virtual int P2 { get; set; }
			static void Main()
			{
				var p1accessor = typeof(A).GetProperty("P1").GetAccessors()[0];
				Console.WriteLine(p1accessor.IsVirtual); // True
				Console.WriteLine(p1accessor.IsFinal); // True
				var p2accessor = typeof(A).GetProperty("P2").GetAccessors()[0];
				Console.WriteLine(p2accessor.IsVirtual); // True
				Console.WriteLine(p2accessor.IsFinal); // False
			}
		}
	}
