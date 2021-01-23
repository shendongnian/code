    List<string> stList = new List<string>();
    
    var process = new Process();
    process.StartInfo.FileName = _dumPcapPath;
    process.StartInfo.Arguments = 
        string.Format("-i " + _interfaceNumber + " -s 65535 -w " + _pcapPath);
    process.Startinfo.WindowStyle = ProcessWindowStyle.Hidden;
    process.Startinfo.RedirectStandardOutput = true;
    process.Startinfo.RedirectStandardError = true;
    process.Startinfo.CreateNoWindow = true;
    process.Startinfo.UseShellExecute = false;
    process.Startinfo.ErrorDialog = false;
    // capture the data received event here...
    process.OutputDataReceived += 
        new DataReceivedEventHandler(process_OutputDataReceived);
    
    process.Start();
    process.BeginOutputReadLine();
    private void process_OutputDataReceived(object sender, DataReceivedEventArgs arg)
    {
        // arg.Data contains the output data from the process...
    }
