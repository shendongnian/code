    public bool StartProcessAndWaitForExit(string command, string args, 
                         string workingDirectory, bool useShellExecute)
    {
        var info = CreateStartInfo(command, args, workingDirectory, useShellExecute);            
        if (info.RedirectStandardOutput) _process.OutputDataReceived += _process_OutputDataReceived;
        if (info.RedirectStandardError) _process.ErrorDataReceived += _process_ErrorDataReceived;
        var logger = _logProvider.GetLogger(GetType().Name);
        try
        {
            _process.Start(info, TimeoutSeconds);
        }
        catch (Exception exception)
        {
            logger.WarnException(log.LogProcessError, exception);
            return false;
        }
        logger.Debug(log.LogProcessCompleted);
        return _process.ExitCode == 0;
    }
