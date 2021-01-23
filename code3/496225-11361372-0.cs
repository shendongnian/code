    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		Thread z = new Thread(new ParameterizedThreadStart(Test)) { Name = "My new thread !" };
    		z.Start();
    
    		Console.ReadKey();
    	}
    
    	private static void Test(object obj)
    	{
    		Console.WriteLine(string.Format("My name is: {0}, my ID is: {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));
    
    		var _timer = new System.Timers.Timer(1000);
    		_timer.Elapsed += (sender, e) =>
    			{
    				Console.WriteLine(string.Format("[Timer] My name is: {0}, my ID is: {1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId));
    			};
    		_timer.Enabled = true;
    		_timer.Start();
    	}
    }
