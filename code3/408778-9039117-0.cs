    void Main()
    {
    	Process process = new Process();
    	process.StartInfo.FileName = "notepad.exe";
    	process.StartInfo.CreateNoWindow = true;
    	process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    	process.StartInfo.UseShellExecute = false;
    	process.StartInfo.RedirectStandardError = true;
    	process.StartInfo.RedirectStandardOutput = true;
    	process.Start();
    	RuntimeMonitor rtm = new RuntimeMonitor(5000);
    	process.WaitForExit();
    	rtm.Close();
    }
    
    public class RuntimeMonitor
    {
    	System.Timers.Timer timer;
    	
    	// Define other methods and classes here
    	public RuntimeMonitor(double intervalMs) // in milliseconds
    	{
    		timer = new System.Timers.Timer();
    		timer.Interval = intervalMs;
    		timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_func);
    		timer.AutoReset = true;
    		timer.Start();
    	}
    	
    	void timer_func(object source, object e)
    	{
    		Console.WriteLine("Yes");
    	}
    	
    	public void Close()
    	{
    		timer.Stop();
    	}
    }
