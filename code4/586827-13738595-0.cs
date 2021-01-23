     public void ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;
    
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
    
            Process = Process.Start(ProcessInfo);
        }
