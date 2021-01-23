	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	namespace Demo
	{
		class Program
		{
			void run()
			{
				double intersect = 0;
				double any = 0;
				Stopwatch stopWatch = new Stopwatch();
				List<string> L1 = Enumerable.Range(0, 10000).Select(x => x.ToString()).ToList();
				List<string> L2 = Enumerable.Range(10000, 10000).Select(x => x.ToString()).ToList();
				for (int i = 0; i < 10; i++)
				{
					stopWatch.Restart();
					Intersect(L1, L2);
					stopWatch.Stop();
					intersect += stopWatch.ElapsedMilliseconds;
					stopWatch.Restart();
					Any(L1, L2);
					stopWatch.Stop();
					any += stopWatch.ElapsedMilliseconds;
				}
				Console.WriteLine("Intersect: " + intersect + "ms");
				Console.WriteLine("Any: " + any + "ms");
			}
			private static bool Any(List<string> lst1, List<string> lst2)
			{
				return lst1.Any(lst2.Contains);
			}
			private static bool Intersect(List<string> lst1, List<string> lst2)
			{
				return lst1.Intersect(lst2).Any();
			}            
			static void Main()
			{
				new Program().run();
			}
		}
	}
