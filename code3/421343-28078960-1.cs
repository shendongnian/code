		using System;
		using System.Collections.Generic;
		using System.Diagnostics;
		namespace ConsoleApplication1
		{
			class Program
			{
				static void Main(string[] args)
				{
					const int ENTRIES = 10000, MAXVAL = 15000, TRIALS = 100000, MULTIPLIER = 2;
					Dictionary<int, int> values = new Dictionary<int, int>();
					Random r = new Random();
					int[] lookups = new int[TRIALS];
					int val;
					List<Tuple<long, long, long>> durations = new List<Tuple<long, long, long>>(8);
					for (int i = 0;i < ENTRIES;++i) try
						{
							values.Add(r.Next(MAXVAL), r.Next());
						}
						catch { --i; }
					for (int i = 0;i < TRIALS;++i) lookups[i] = r.Next(MAXVAL);
					Stopwatch sw = new Stopwatch();
					ConsoleColor bu = Console.ForegroundColor;
					for (int size = 10;size <= TRIALS;size *= MULTIPLIER)
					{
						long a, b, c;
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Loop size: {0}", size);
						Console.ForegroundColor = bu;
						// ---------------------------------------------------------------------
						sw.Start();
						for (int i = 0;i < size;++i) values.TryGetValue(lookups[i], out val);
						sw.Stop();
						Console.WriteLine("TryGetValue: {0}", a = sw.ElapsedTicks);
						// ---------------------------------------------------------------------
						sw.Restart();
						for (int i = 0;i < size;++i) val = values.ContainsKey(lookups[i]) ? values[lookups[i]] : default(int);
						sw.Stop();
						Console.WriteLine("ContainsKey: {0}", b = sw.ElapsedTicks);
						// ---------------------------------------------------------------------
						sw.Restart();
						for (int i = 0;i < size;++i)
							try { val = values[lookups[i]]; }
							catch { }
						sw.Stop();
						Console.WriteLine("try-catch: {0}", c = sw.ElapsedTicks);
						// ---------------------------------------------------------------------
						Console.WriteLine();
						durations.Add(new Tuple<long, long, long>(a, b, c));
					}
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Finished evaluation .... Time distribution:");
					Console.ForegroundColor = bu;
					val = 10;
					foreach (Tuple<long, long, long> d in durations)
					{
						long sum = d.Item1 + d.Item2 + d.Item3;
						Console.WriteLine("Size: {0:D6}:", val);
						Console.WriteLine("TryGetValue: {0:P2}, ContainsKey: {1:P2}, try-catch: {2:P2} - Total: {3:N}", (decimal)d.Item1 / sum, (decimal)d.Item2 / sum, (decimal)d.Item3 / sum, sum);
						val *= MULTIPLIER;
					}
					Console.WriteLine();
				}
			}
		}
