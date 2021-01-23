	using System;
	using System.Threading;
	using System.Diagnostics;
	
	public class Program
	{
		public static void Main()
		{
			(new Example()).Main();
		}
	}
	
	public class Example
	{
		public void Main()
		{
			System.Timers.Timer t = new System.Timers.Timer(10);
			t.Enabled = true;
			t.Elapsed += (sender, args) => c();
			Console.ReadLine(); t.Enabled = false;
		}
	
		int t = 0;
		int h = 0;
		public void c()
		{
			h++;
			new Thread(() => doWork(h)).Start();
		}
	
		public void doWork(int h2)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			try
			{
				t++;
				Console.WriteLine("h={0}, h2={1}, threads={2} [start]", h, h2, t);
				Thread.Sleep(3000);
			}
			finally
			{
				sw.Stop();
				var tim = sw.Elapsed;
				var elapsedMS = tim.Seconds * 1000 + tim.Milliseconds;
				t--;
				Console.WriteLine("h={0}, h2={1}, threads={2} [end, sleep time={3} ms] ", h, h2, t, elapsedMS);
			}
		}
	}
