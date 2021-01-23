    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    namespace Iterating_types
    {
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch watch = new Stopwatch();
			int UPPER = 10000;
			int[] int_arr = Enumerable.Range(1, UPPER).ToArray();
			List<int> int_list = Enumerable.Range(1, UPPER).ToList();
			Int32[] int32_arr = Enumerable.Range(1, UPPER).ToArray();
			Int64[] int64_arr = new Int64[UPPER]; 
			string[] string_arr = new string[UPPER];
			List<string> string_list = new List<string>();
			// Initializing some of the above
			for (int i = 0; i < UPPER; i++)
			{
				int64_arr[i] = (Int64) i;
				string_arr[i] = i.ToString();
				string_list.Add(i.ToString());
			}
			Console.WriteLine("Iterations: {0}{1}", UPPER, Environment.NewLine);
			watch.Start();
			int temp_int;
			for (int i = 0; i < UPPER; i++)
			{
				temp_int = int_arr[i];
			}
			watch.Stop();
			Console.WriteLine("Type: Int\tStructure: Array\tticks: {0}", watch.ElapsedTicks);
			watch.Reset();
			watch.Start();
			Int32 temp_int32 ;
			for (int i = 0; i < UPPER; i++)
			{
				temp_int32 = int32_arr[i];
			}
			watch.Stop();
			Console.WriteLine("Type: Int32\tStructure: Array\tticks: {0}", watch.ElapsedTicks);
			watch.Reset();
			watch.Start();
			Int64 temp_int64 ;
			for (int i = 0; i < UPPER; i++)
			{
				temp_int64 = int64_arr[i];
			}
			watch.Stop();
			Console.WriteLine("Type: Int64\tStructure: Array\tticks: {0}", watch.ElapsedTicks);
			watch.Reset();
			watch.Start();
			string s ;
			for (int i = 0; i < UPPER; i++)
			{
				s = string_arr[i];
			}
			watch.Stop();
			Console.WriteLine("Type: string\tStructure: Array\tticks: {0}", watch.ElapsedTicks);
			watch.Reset();
			watch.Start();
			foreach (var val in int_list)
			{
				temp_int = val;
			}
			watch.Stop();
			Console.WriteLine("Type: Int\tStructure: List\t\tticks: {0}", watch.ElapsedTicks);
			watch.Reset();
			watch.Start();
			foreach (var val in string_list)
			{
				s = val;
			}
			watch.Stop();
			Console.WriteLine("Type: string\tStructure: List\t\tticks: {0}", watch.ElapsedTicks);
			Console.WriteLine();
			Console.WriteLine("Hit any key to exit.");
			Console.ReadKey();
		}
	}
    }
