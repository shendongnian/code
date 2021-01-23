    using System;
    using System.Threading;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Collections;
    namespace benchmark
    {
	class Program
	{
		public static Random m_Rand = new Random();
		public static Dictionary<int, int> testdict = new Dictionary<int, int>();
		public static Hashtable testhash = new Hashtable();
		public static void Main(string[] args)
		{
			Console.WriteLine("Adding elements into hashtable...");
			Stopwatch watch = Stopwatch.StartNew();
			for(int i=0; i<1000000; i++)
				testhash[i]=m_Rand.Next();
			watch.Stop();
			Console.WriteLine("Done in {0:F4} -- pause....", watch.Elapsed.TotalSeconds);
			Thread.Sleep(4000);
			Console.WriteLine("Adding elements into dictionary...");
			watch = Stopwatch.StartNew();
			for(int i=0; i<1000000; i++)
				testdict[i]=m_Rand.Next();
			watch.Stop();
			Console.WriteLine("Done in {0:F4} -- pause....", watch.Elapsed.TotalSeconds);
			Thread.Sleep(4000);
			
			Console.WriteLine("Finding the first free number for insertion");
			Console.WriteLine("First method: ContainsKey");
			watch = Stopwatch.StartNew();
			int intero=0;
			while (testdict.ContainsKey(intero))
			{
				intero++;
			}
			testdict.Add(intero, m_Rand.Next());
			watch.Stop();
			Console.WriteLine("Done in {0:F4} -- added value {1} in dictionary -- pause....", watch.Elapsed.TotalSeconds, intero);
			Thread.Sleep(4000);
			Console.WriteLine("Second method: TryGetValue");
			watch = Stopwatch.StartNew();
			intero=0;
			int result=0;
			while(testdict.TryGetValue(intero, out result))
			{
				intero++;
			}
			testdict.Add(intero, m_Rand.Next());
			watch.Stop();
			Console.WriteLine("Done in {0:F4} -- added value {1} in dictionary -- pause....", watch.Elapsed.TotalSeconds, intero);
			Thread.Sleep(4000);
			Console.WriteLine("Test hashtable");
			watch = Stopwatch.StartNew();
			intero=0;
			while(testhash.Contains(intero))
			{
				intero++;
			}
			testhash.Add(intero, m_Rand.Next());
			watch.Stop();
			Console.WriteLine("Done in {0:F4} -- added value {1} into hashtable -- pause....", watch.Elapsed.TotalSeconds, intero);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
    }
