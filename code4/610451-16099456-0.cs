    try
    {
    // Start the child process.
        Process p = new Process();
        // Redirect the output stream of the child process.
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = "C:\Path\To\App.exe";
        p.Start();
    }
    
    // Uses the ProcessStartInfo class to start new processes,
    // both in a minimized mode.
    
    void OpenWithStartInfo()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
    
        Process.Start(startInfo);
    
        startInfo.Arguments = "www.northwindtraders.com";
    
        Process.Start(startInfo);
    }
