    public int ExecuteCommand(CommandParameters parameters)
    {
      Process process = new Process();
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.RedirectStandardError = true;
      process.OutputDataReceived += StdOutputHandler;
      process.ErrorDataReceived += StdErrorHandler;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.FileName = ...;
      process.StartInfo.Arguments = ...;
      process.Start();
      process.BeginErrorReadLine();
      process.BeginOutputReadLine();
      process.WaitForExit(parameters.Timeout);
      return process.ExitCode;
    }
    private void StdOutputHandler(object sendingProcess, DataReceivedEventArgs outdata)
    {
      if (!string.IsNullOrEmpty(outdata.Data))
      {
        OutputMessages.Add(outdata.Data);
      }
    }
