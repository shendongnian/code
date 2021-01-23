    // for every line written to stdOut, raise a progress event
    int result = SystemUtils.SpawnProcessSynchronous(fileName, args, out placeholder, false,
        (sender, eventArgs) =>
        {
            stdOut += (stdOut.Length > 0)
                        ? Environment.NewLine
                        : "" + eventArgs.Data;
            // Too much info
            //_output.Status.Details.Add(eventArgs.Data);
            StandardEvents.OnUpdateProgress(
                StandardCommandEvents.UpdateProgressMode.bumpProgress,
                new UpdateProgressArgs(eventArgs.Data));
        });
        
    public static int SpawnProcessSynchronous(string fileName, string args, out string stdOut, bool isVisible, DataReceivedEventHandler OutputDataReceivedDelegate)
    {
        int returnValue = 0;
        var processInfo = new ProcessStartInfo();
        stdOut = "";
        processInfo.FileName = fileName;
        processInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        log.Debug("Set working directory to: {0}", processInfo.WorkingDirectory);
        processInfo.WindowStyle = isVisible ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardOutput = true;
        processInfo.CreateNoWindow = true;
        processInfo.Arguments = args;
        using (Process process = Process.Start(processInfo))
        {
            if (OutputDataReceivedDelegate != null)
            {
                process.OutputDataReceived += OutputDataReceivedDelegate;
                process.BeginOutputReadLine();
            }
            else
            {
                stdOut = process.StandardOutput.ReadToEnd();
            }
            // do not reverse order of synchronous read to end and WaitForExit or deadlock
            // Wait for the process to end.  
            process.WaitForExit();
            returnValue = process.ExitCode;
        }
        return returnValue;
    }
