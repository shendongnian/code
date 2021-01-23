    ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c java -version");
    procStartInfo.RedirectStandardOutput = true;
    procStartInfo.RedirectStandardError = true;
    procStartInfo.UseShellExecute = false;
    procStartInfo.CreateNoWindow = true;
    Process proc = new Process();
    proc.StartInfo = procStartInfo;
    proc.EnableRaisingEvents = true;
    // create event and wait for data receive
    proc.OutputDataReceived += new DataReceivedEventHandler(proc_OutputDataReceived);
    proc.ErrorDataReceived += new DataReceivedEventHandler(proc_ErrorDataReceived);
    proc.Start();
    proc.BeginOutputReadLine();
    proc.BeginErrorReadLine();
    proc.WaitForExit();
    static void proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        string s = e.Data;
    }
    
    static void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        string s = e.Data;
    }
