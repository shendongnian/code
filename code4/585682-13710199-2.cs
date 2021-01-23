	class Program
	{
		static void Main(string[] args)
		{
			var timer = new System.Timers.Timer();
			timer.Interval = 2000; // 2 seconds here
			timer.AutoReset = true; //Restart 
			Action<object, EventArgs> Elapsed = (object o, EventArgs e) => Console.WriteLine(DateTime.Now);
			timer.Elapsed += new System.Timers.ElapsedEventHandler(Elapsed);
			timer.Start();
			while (Console.ReadLine() != "quit")
			{
				timer.Stop();
				Elapsed.Invoke(new object(), EventArgs.Empty);
				timer.Start();
			
			}
		}
	}
