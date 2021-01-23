	using System;
	using System.Threading;
				
	public class Program
	{	
		public void Main() 
		{ 
			System.Timers.Timer t = new System.Timers.Timer (10); 
			t.Enabled=true; 
			t.Elapsed+= (sender, args) =>c(); 
			Console.ReadLine(); 
		} 
	
		int t=0; int h=0; 
		
		public void c() 
		{ 
			h++; new Thread(() => doWork(h)).Start(); 
		} 
		
		public void doWork(int h2) 
		{ 
			try 
			{
				t++; string.Format("h={0}, h2={1}, threads={2} [start]", 
									h, h2, t).Dump();
				Thread.Sleep(3000); 
			}
			finally 
			{
				t--; string.Format("h={0}, h2={1}, threads={2} [end]", 
									h, h2, t).Dump();
			}
		} 		
	}
