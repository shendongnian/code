    Process[] prs = Process.GetProcesses();
        while(true)
        {
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "GameRanger")
                {
    
                    pr.Kill();
    
                }
    	    Thread.Sleep(TimeYouLike);
    	    prs = Process.GetProcesses();// **Update the process list**
            }
        }
