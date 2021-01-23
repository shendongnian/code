		private static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			for (int trial = 0; trial < 4; ++trial)
			{
				sw.Restart();
				Interlocked.MemoryBarrier();
				loop1();
				Interlocked.MemoryBarrier();
				Console.WriteLine("loop1() took " + sw.Elapsed);
				sw.Restart();
				Interlocked.MemoryBarrier();
				loop2();
				Interlocked.MemoryBarrier();
				Console.WriteLine("loop2() took " + sw.Elapsed);
				sw.Restart();
				Interlocked.MemoryBarrier();
				loop3();
				Interlocked.MemoryBarrier();
				Console.WriteLine("loop3() took " + sw.Elapsed);
				
				// Console.WriteLine(); // <-- Uncomment this and the timings don't change now.
			}
		}
