    using System.Diagnostics;
    static void Main(string[] args)
    	{
    		String thisprocessname = Process.GetCurrentProcess().ProcessName;
    	    	if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
    			return;			
    	}
