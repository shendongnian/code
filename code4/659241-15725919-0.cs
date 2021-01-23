    _processInfoTest = new ProcessStartInfo();
    _processInfoTest.FileName = serviceSettings.PlinkExecutable;
    _processInfoTest.Arguments = GetPlinkArguments(serviceSettings);
    _processInfoTest.RedirectStandardOutput = true;
    _processInfoTest.RedirectStandardError = true;
    _processInfoTest.RedirectStandardInput = true;
    _processInfoTest.UseShellExecute = false;
    _processInfoTest.CreateNoWindow = true;
    
    WcfServerHelper.BroadcastRemoteCallback(x => x.PlinkTextOutput(_processInfoTest.Arguments, DateTime.Now));
    
    _processTest = new Process();
    _processTest.StartInfo = _processInfoTest;
    _processTest.Start();
    
    Task.Factory.StartNew(() =>
        {
            ProcessOutputCharacters(_processTest.StandardError);
        });
    
    Task.Factory.StartNew(() =>
        {
            ProcessOutputCharacters(_processTest.StandardOutput);
        });
