    while(true)
    {
    	SearchAndDestroy("MyProgProc");
    }
    
    
    public SearchAndDestroy(string programname)
    	{
    	 foreach (Process _proc in Process.GetProcesses()) {
    				if (_proc.ProcessName.StartsWith(name))
    				_proc.Kill();
    			}
    	}
