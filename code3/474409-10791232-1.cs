	using System;
	using System.Collections.Generic;
	public class A
	{
		public virtual void Process()
		{
			// Do algorithm for type A
			Console.WriteLine("In A.Process()");
		}
	}
	public class B : A
	{
		public override void Process()
		{
			// Do algorithm for type B
			Console.WriteLine("In B.Process()");
		}
	}
	public static class Manager
	{
		// Does internal processing
		public static void ProcessInternal(List<A> items)
		{
			foreach(A item in items)
			{
				item.Process();	// Call A.Process() or B.Process() depending on type
				ProcessExternal(item);
			}
		}
		
		public static void ProcessExternal(A a)
		{
			Console.WriteLine(a.ToString());
		}
		
		public static void ProcessExternal(B b)
		{
			Console.WriteLine(b.ToString());
		}
		
		public static void Main(String[] args)
		{
			List<A> objects = new List<A>();
			objects.Add(new A());
			objects.Add(new B());
			ProcessInternal(objects);
		}
	}
