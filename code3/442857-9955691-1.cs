        processes = Process.GetProcessesByName(procName);
        foreach (Process proc in processes)
        {
            if(proc.MainWindowTitle.equals(myTitle))
            {  	        
	        proc.CloseMainWindow();
	        proc.WaitForExit(); or use tempProc.Close();
            }
	}
