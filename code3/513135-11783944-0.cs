    ProcessInfo = new ProcessStartInfo(command);
        ProcessInfo.RedirectStandardOutput = true;
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.UseShellExecute = false;
        Process = Process.Start(ProcessInfo);                    
        Process.Close(); 
