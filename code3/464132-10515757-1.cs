    Process[] procs = Process.GetProcesses();
    IntPtr hWnd;
    foreach(Process proc in procs)
    {
       if ((hWnd = proc.MainWindowHandle) != IntPtr.Zero)
       {
          Console.WriteLine("{0} : {1}", proc.ProcessName, hWnd);
       }
    }
