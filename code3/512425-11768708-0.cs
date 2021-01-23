    var shellProcess = System.Diagnostics.Process.Start(info);
    shellProcess.EnableRaisingEvents = true;
    shellProcess.Exited += ProcessExited;
    
    shellProcess.OutputDataReceived += ShellProcess_OutputDataReceived;
    shellProcess.ErrorDataReceived  += ShellProcess_ErrorDataReceived;
    shellProcess.BeginOutputReadLine();
    shellProcess.BeginErrorReadLine();
    void ShellProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
    	// Do Something
    }
    
    void ShellProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
    	// Do Something
    }
