	using System;
	using System.Collections.Generic;
	public class A
	{
		public String Value
		{
			get;
			set;
		}
		
		public A()
		{
			Value = "A's value";
		}
		
		public virtual void Process()
		{
			// Do algorithm for type A
			Console.WriteLine("In A.Process()");
		}
	}
	public class B : A
	{
		public int Health
		{
			get;
			set;
		}
	
		public B()
		{
			Value = "B's value";
			Health = 100;
		}
		
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
			foreach(dynamic item in items)
			{
				item.Process();	// Call A.Process() or B.Process() depending on type
				ProcessExternal(item);
			}
		}
		public static void ProcessExternal(A a)
		{
			Console.WriteLine(a.Value);
		}
		
		public static void ProcessExternal(B b)
		{
			Console.WriteLine(b.Health);
		}
		
		public static void Main(String[] args)
		{
			List<A> objects = new List<A>();
			objects.Add(new A());
			objects.Add(new B());
			ProcessInternal(objects);
		}
	}
