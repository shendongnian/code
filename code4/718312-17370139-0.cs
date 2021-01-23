    using System;
    using System.Collections.Generic;
    // don't add this, lest you bring it in
    //using System.Linq;
    using Linq = System.Linq.Enumerable;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var values = new List<int>(Linq.Range(0, 10));
    			var useLinqFirst = Linq.First(values);
    			Console.WriteLine("LINQ First(): {0}", useLinqFirst);
    			var useMyFirst = values.First();
    			Console.WriteLine("My First(): {0}", useMyFirst);
    			Console.ReadLine();
    		}
    	}
    
    	public static class Ext
    	{
    		public static T First<T>(this IEnumerable<T> src)
    		{
    			Console.WriteLine("Using my First!");
    			var e = src.GetEnumerator();
    			while (e.MoveNext())
    			{
    				return e.Current;
    			}
    			return default(T);
    		}
    	}
    }
