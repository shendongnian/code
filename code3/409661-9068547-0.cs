    using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	class Program
	{
		static void Main(string[] args)
		{
			var seq =
			Enumerable.Range(0, 100)
				.Select(i => new { Name = "Item" + i, Value = i })
				;
			seq.WriteCsv(Console.Out);
			Console.ReadLine();
		}
	}
	public static class CsvExtension
	{
		public static void WriteCsv<T>(this IEnumerable<T> seq, TextWriter writer)
		{
			var type = typeof(T);
			MethodInfo[] getters = type.GetProperties().Select(pi => pi.GetGetMethod()).ToArray();
			// only supporting simple properties
			// indexer properties will probably fail
			var args = new object[0];
			foreach (var item in seq)
			{
				for (int i = 0; i < getters.Length; i++)
				{
					if (i != 0)
						writer.Write(",");
					Object value = getters[i].Invoke(item, args);
					var str = value.ToString();
				
					if (str.Contains(",") || str.Contains("\""))
					{
						var escaped = str.Replace("\"", "\\\"");
						writer.Write("\"");
						writer.Write(escaped);
						writer.Write("\"");
					}
					else
					{
						writer.Write(str);
					}
				}
				writer.WriteLine();
			}
		}
	}
