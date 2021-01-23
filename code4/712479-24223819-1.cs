    // Create a new process
    Process proc;
    
    // Start the process
    proc = Process.Start(Application.StartupPath + @"\App2.exe");
    proc.WaitForInputIdle();
    
    // Add this by using using System.Threading;
    Thread.Sleep(500);
    
    // Set the panel control as the application's parent
    SetParent(proc.MainWindowHandle, this.panel1.Handle);
