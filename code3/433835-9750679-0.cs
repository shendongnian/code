	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	namespace ConsoleApplication3
	{
		delegate void myFoo(int i, string s);
		internal class Program
		{
			private static void Main(string[] args)
			{
				Foo(1, "hello");
				// From a delegate
				try
				{
					Delegate Food = (myFoo)Foo;
					((dynamic)Food).Invoke(2, null);
				}
				catch (NullReferenceException ex)
				{ Console.WriteLine("Caught NullReferenceException at " + ex.StackTrace); }
				MethodInfo Foom = typeof(Program).GetMethod("Foo", BindingFlags.Static | BindingFlags.NonPublic);
				// From a MethodInfo, obtaining a delegate from it
				try
				{
					Delegate Food = Delegate.CreateDelegate(typeof(Action<,>).MakeGenericType(Foom.GetParameters().Select(p => p.ParameterType).ToArray()), Foom);
					((dynamic)Food).Invoke(2, null);
				}
				catch (NullReferenceException ex)
				{ Console.WriteLine("Caught NullReferenceException at " + ex.StackTrace); }
				// From a MethodInfo, creating a plain Action
				try
				{
					Expression.Lambda<Action>(
						Expression.Call(
							Foom,
							Expression.Constant(2),
							Expression.Constant(null, typeof(string)))).Compile()();
				}
				catch (NullReferenceException ex)
				{ Console.WriteLine("Caught NullReferenceException at " + ex.StackTrace); }
				// MethodBase.Invoke, exception gets wrapped
				try
				{
					Foom.Invoke(null, new object[] { 2, null });
				}
				catch (NullReferenceException)
				{ Console.WriteLine("Won't catch NullReferenceException"); }
				catch (TargetInvocationException)
				{ Console.WriteLine("Bad!"); }
				// DynamicInvoke, exception gets wrapped
				try
				{
					Delegate Food = (myFoo)Foo;
					Food.DynamicInvoke(2, null);
				}
				catch (NullReferenceException)
				{ Console.WriteLine("Won't catch NullReferenceException"); }
				catch (TargetInvocationException)
				{ Console.WriteLine("Bad!"); }
			}
			private static void Foo(int i, string s)
			{
				Console.WriteLine("i=" + i + ", s.Length = " + s.Length);
			}
		}
	}
