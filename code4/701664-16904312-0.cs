    using (var process = new Process())
    {
        process.StartInfo = new ProcessStartInfo("exename");
        process.StartInfo.RedirectStandardOutput = true;
    
        process.OutputDataReceived += (s, ev) =>
        {
            string output = ev.Data;
        };
    
    
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();
    }
