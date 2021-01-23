    using System;
    using System.Reflection;
    namespace EnforceStaticMethod
    {
	class Program
	{
		static void Main()
		{
			var objA = GetProduct(typeof (TypeA), 1);
			var objB = GetProduct(typeof (TypeB), 2);
			Console.WriteLine("objA has type: " + objA.GetType());
			Console.WriteLine("objB has type: " + objB.GetType());
		}
		static object GetProduct(Type type, int id)
		{
			var argTypes = new[] {typeof (int)};
			var method = type.GetMethod("GetProduct", BindingFlags.Static | BindingFlags.Public, null, argTypes, null);
			if (method == null)
			{
				throw new ArgumentException("Type does not have GetProduct method: " + type);
			}
			var args = new object[] {id};
			return method.Invoke(null, args);
		}
	}
	class TypeA
	{
		public static object GetProduct(int id)
		{
			return new TypeA();
		}
	}
	class TypeB
	{
		public static object GetProduct(int id)
		{
			return new TypeB();
		}
	}
    }
