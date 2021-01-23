    Process []pArry = Process.GetProcesses();
    
    foreach(Process p in pArry)
    {       
        if (p.ProcessName.CompareTo("yourapp") ==0)
        {
           p.Kill();
           break; 
        }
    }
    p.WaitForExit(); // This is blocking so be careful, maybe it should be run in other thread
