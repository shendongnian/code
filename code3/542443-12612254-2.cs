	using System;
	using System.Text;
	using System.Reflection;
	namespace App
	{
		class Program
		{
			static void Main(string[] args)
			{
				A.IA ia;
				Assembly b;
				Type tb;
				A.A a;
				a = new A.A(null);
				b = Assembly.LoadFrom("../../../B/bin/Debug/B.dll");
				tb = b.GetType("B._B");
				ia = (A.IA)tb.GetConstructor(new Type[] { typeof(A.A) }).Invoke(new object[]{a});
				a.a = ia;
				a.callA();
			}
		}
	}
