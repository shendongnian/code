    string filename = "E:\\sox-14-4-0\\mysamplevoice.wav";
    Process p = new Process();
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.FileName = "E:\\sox-14-4-0\\sox.exe ";
    p.StartInfo.Arguments = filename + " -n stat";
    
    p.OutputDataReceived += process_OutputDataReceived;
    p.ErrorDataReceived += process_ErrorDataReceived;
    
    p.Start();
    p.BeginErrorReadLine();
    p.BeginOutputReadLine();
    void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        string s = e.Data;
    }
    void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        string s = e.Data;
    }
