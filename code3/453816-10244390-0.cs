    private void startProducts(string startScript)
    {
        //Thread productThread = new Thread();
        Process startProductProcess = new Process();
        // Save tag
        _processTags.Add(startProductProcess, Thread.CurrentThread.Name);
        startProductProcess.StartInfo.FileName = startScript;
        startProductProcess.StartInfo.UseShellExecute = false;
        startProductProcess.StartInfo.RedirectStandardOutput = true;
        StringBuilder processOutput = new StringBuilder("");
        startProductProcess.OutputDataReceived += new DataReceivedEventHandler(startProductProcess_OutputDataReceived);
        startProductProcess.Start();
        startProductProcess.BeginOutputReadLine();
    }
