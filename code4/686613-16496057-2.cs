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
				int UPPER = 1000000;
				int[] int_arr = Enumerable.Range(1, UPPER).ToArray();
				List<int> int_list = Enumerable.Range(1, UPPER).ToList();
				Int32[] int32_arr = Enumerable.Range(1, UPPER).ToArray();
				Int64[] int64_arr = new Int64[UPPER]; 
				IntObject[] intobject_arr = new IntObject[UPPER];
				List<IntObject> intobject_list = new List<IntObject>();
				string[] string_arr = new string[UPPER];
				List<string> string_list = new List<string>();
				// Initializing some of the above
				for (int i = 0; i < UPPER; i++)
				{
					int64_arr[i] = (Int64) i;
					string_arr[i] = i.ToString();
					string_list.Add(i.ToString());
					intobject_arr[i] = new IntObject(i);
					intobject_list.Add(new IntObject(i));
				}
				Console.WriteLine("Iterations: {0}{1}", UPPER, Environment.NewLine);
				Console.WriteLine("\n\rArrays:\t----------------------------------------------");
				
				watch.Start();
				int temp_int;
				for (int i = 0; i < UPPER; i++)
				{
					temp_int = int_arr[i];
				}
				watch.Stop();
				Console.WriteLine("Type: Int\tStructure: Array\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				watch.Reset();
				watch.Start();
				Int32 temp_int32 ;
				for (int i = 0; i < UPPER; i++)
				{
					temp_int32 = int32_arr[i];
				}
				watch.Stop();
				Console.WriteLine("Type: Int32\tStructure: Array\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				watch.Reset();
				watch.Start();
				Int64 temp_int64 ;
				for (int i = 0; i < UPPER; i++)
				{
					temp_int64 = int64_arr[i];
				}
				watch.Stop();
				Console.WriteLine("Type: Int64\tStructure: Array\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				watch.Reset();
				watch.Start();
				string s ;
				for (int i = 0; i < UPPER; i++)
				{
					s = string_arr[i];
				}
				watch.Stop();
				Console.WriteLine("Type: string\tStructure: Array\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				watch.Reset();
				watch.Start();
				for (int i = 0; i < UPPER; i++)
				{
					temp_int = intobject_arr[i].IntValue;
				}
				watch.Stop();
				Console.WriteLine("Type: IntObject\tStructure: Array\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				Console.WriteLine("\n\rLists:\t----------------------------------------------");
				
				watch.Reset();
				watch.Start();
				foreach (var val in int_list)
				{
					temp_int = val;
				}
				watch.Stop();
				Console.WriteLine("Type: Int\tStructure: List\t\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				watch.Reset();
				watch.Start();
				foreach (var val in string_list)
				{
					s = val;
				}
				watch.Stop();
				Console.WriteLine("Type: string\tStructure: List\t\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				watch.Reset();
				watch.Start();
				foreach (var val in intobject_list)
				{
					temp_int = val.IntValue;
				}
				watch.Stop();
				Console.WriteLine("Type: IntObject\tStructure: List\t\tticks: {0}\tMiliSeconds:{1}", watch.ElapsedTicks, watch.ElapsedMilliseconds);
				Console.WriteLine();
				Console.WriteLine("Hit any key to exit.");
				Console.ReadKey();
			}
		}
		class IntObject
		{
			public int IntValue { get; set; }
			public IntObject ()
			{
				IntValue = 0;
			}
			public IntObject(int i)
			{
				IntValue = i;
			}
		}
    }
