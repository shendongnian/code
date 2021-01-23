    using System;
    using System.Reflection;
    namespace ReflectionExample
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			Type[] types = typeof (MyClass).Assembly.GetTypes();
    
    			foreach (Type type in types)
    			{
    				Console.WriteLine(type.Name);
    
    				MemberInfo[] members = type.GetMembers(
    					BindingFlags.Instance | BindingFlags.Public
    					| BindingFlags.FlattenHierarchy | BindingFlags.DeclaredOnly);
    
    				foreach (MemberInfo memberInfo in members)
    				{
    					Console.WriteLine("\t" + memberInfo.Name);
    				}
    			}
    
    			Console.ReadLine();
    		}
    
    		public class MyClass
    		{
    			public int Bar { get; set; }
    
    			public void AMethod()
    			{
    				Console.WriteLine("foo");
    			}
    
    			public void BMethod()
    			{
    				Console.WriteLine("foo");
    			}
    
    			public void CMethod()
    			{
    				Console.WriteLine("foo");
    			}
    		}
    	}
    }
