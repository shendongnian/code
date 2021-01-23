    SynchronizationContext _syncContext;
    MyForm()
    {
    	_syncContext = SynchronizationContext.Current;
    }
    
    void StartProcess()
    {
    	var process = new Process
    	{
    		StartInfo = new ProcessStartInfo
    		{
    			FileName = "myProcess.exe",
    			UseShellExecute = false,
    			RedirectStandardOutput = true,
    			RedirectStandardError = true,
    		}
    	};
    	
    	process.OutputDataReceived += (sender, args) => Display(args.Data);
    	process.ErrorDataReceived += (sender, args) => Display(args.Data);
    	
    	process.Start();
    	process.BeginOutputReadLine();
    	process.BeginErrorReadLine();
    	
    	process.WaitForExit(); //you need this in order to flush the output buffer
    }
    
    void Display(string output)
    {
    	_syncContext.Post(_ => myTextBox.AppendText(output), null);
    }
