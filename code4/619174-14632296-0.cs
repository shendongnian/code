    using System.Diagnostics;
    
    
    Process[] processlist = Process.GetProcesses();
    
    foreach(Process theprocess in processlist)
    {
          
        if(theprocess.ProcessName.StartsWith("cheat");
             theprocess.Kill(); 
    }
