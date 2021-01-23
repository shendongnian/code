    int process = 0;
    foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
    {
       if (myProc.ProcessName == "process name")
          process++;
       if (process < 2)
          p.Start();
    }
