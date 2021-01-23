    public static Task RunProcessAsync(string processPath)
    {
        var tcs = new TaskCompletionSource<object>();
        var process = new Process
        {
            EnableRaisingEvents = true,
            StartInfo = new ProcessStartInfo(processPath)
            {
                RedirectStandardError = true,
                UseShellExecute = false
            }
        };
        process.Exited += (sender, args) =>
        {
            if (process.ExitCode != 0)
            {
                var errorMessage = process.StandardError.ReadToEnd();
                tcs.SetException(new InvalidOperationException("The process did not exit correctly. " +
                    "The corresponding error message was: " + errorMessage));
            }
            else
    		{
    			tcs.SetResult(null);
    		}
            process.Dispose();
        };
        process.Start();
        return tcs.Task;
    }
