        // Create a new process
        Process proc;
        // Start the process
        proc = Process.Start(Application.StartupPath + @"\App2.exe");
        proc.WaitForInputIdle();
        // Add this by using using System.Threading;<br>
        Thread.Sleep(500);<br>
        // Set the panel control as the application's parent
        SetParent(proc.MainWindowHandle, this.panel1.Handle);
