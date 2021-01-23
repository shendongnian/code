        processes = Process.GetProcessesByName(procName);
        foreach (Process proc in processes)
        {
            if(proc.MainWindowTitle.equals(myTitle))
            {  
	        Process tempProc=Process.GetProcessById(proc.Id);
	        tempProc.CloseMainWindow();
	        tempProc.WaitForExit(); or use tempProc.Close();
            }
	}
