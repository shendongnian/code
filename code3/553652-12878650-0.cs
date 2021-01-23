    process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
    ...
    void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Process p = (Process) sender;
        if(p.HasExited) ...
    }
