	class Program
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.Name = "MAIN";
			Task workTask = DoWork();
			workTask.Wait(); // Just wait, and the thread will continue
                             //  when the work is complete
			Console.Write("Method successfully executed. Executing callback method in thread:" +
					"\n" + Thread.CurrentThread.Name);
			Console.Read();
		}
		static Task DoWork()
		{
			Console.Write(Thread.CurrentThread.Name); // show on what thred we are executing
			Task doWork = new Task(() =>
			{
				Console.Write(Thread.CurrentThread.Name); // show on what thred we are executing
				Thread.Sleep(4000);
			});
			doWork.Start(); 
			return doWork;
		}
	}
