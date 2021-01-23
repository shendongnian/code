    Process[] proces = Process.GetProcessesByName("WINWORD");
    foreach (Process proc in proces)
    
    {
  
       proc.PriorityClass = ProcessPriorityClass.RealTime;
    }
