    using System.Diagnostics;
    Process [] processes = System.Diagnostics.Process.GetProcesses();
    foreach (System.Diagnostics.Process process in processes)
    {
        if (process.MainWindowHandle == hWndTray)
        {
            // ...
        }
    }
