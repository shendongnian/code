    public void StartProcess(string Filename, string Arguments)
    {
        currentProcess = new Process();
        currentProcess.StartInfo.FileName = Programm;
        currentProcess.StartInfo.Arguments = Arguments;
        currentProcess.StartInfo.UseShellExecute = false;
        currentProcess.StartInfo.RedirectStandardOutput = true;
        currentProcess.StartInfo.RedirectStandardError = true;
        currentProcess.OutputDataReceived += OutputReceivedEvent;
        currentProcess.ErrorDataReceived += ErrorReceivedEvent; 
        currentProcess.EnableRaisingEvents = true;
        string path = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_Result.txt";
        LastResult = path;
        resultfile = File.CreateText(path);
        currentProcess.Start();
        currentProcess.BeginOutputReadLine();
        currentProcess.BeginErrorReadLine();
        response.command = Command.ACK;
        SendMessage(response);
    }
    private void OutputReceivedEvent(object sender, DataReceivedEventArgs e)
    {
        resultfile.WriteLine(e.Data);
    }
    /*This second event handler is to prevent a lock occuring from reading two separate streams. 
    Not always an issue, but good to protect yourself either way. */
    private void ErrorReceivedEvent(object sender, DataReceivedEventArgs e)
    {
        resultfile.WriteLine(e.Data);
    }
