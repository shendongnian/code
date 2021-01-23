    public static class WindowsProcessUtil
    {
        /// <summary>
        /// Spawn a Windows process, capture StandardOut and StandardError, and wait for it to complete
        /// </summary>
        public static WindowsProcessResult RunProcess(string exePath, string cmdLineArgs, TimeSpan? timeout = null)
        {
            Process p = null;
            StringBuilder processOutput = new StringBuilder();
            StringBuilder processError = new StringBuilder();
            int exitCode = 0;
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(exePath, cmdLineArgs);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.CreateNoWindow = true;
                psi.WorkingDirectory = Path.GetDirectoryName(exePath);
                psi.EnvironmentVariables["Path"] = psi.EnvironmentVariables["Path"] + ";" + Path.GetDirectoryName(exePath);
                psi.LoadUserProfile = true;
                p = new Process();
                p.StartInfo = psi;
                p.EnableRaisingEvents = true;
                p.OutputDataReceived += (o, args) =>
                {
                    processOutput.AppendLine(args.Data);
                };
                p.ErrorDataReceived += (o, args) =>
                {
                    processError.AppendLine(args.Data);
                };
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                if (timeout.HasValue)
                {
                    bool processExited = p.WaitForExit((int)timeout.Value.TotalMilliseconds);
                    if (!processExited)
                    {
                        p.Kill();
                        throw new TimeoutException("Process did not complete after " + timeout.Value.TotalMilliseconds + " msec");
                    }
                }
                else
                {
                    p.WaitForExit();
                }
                exitCode = p.ExitCode;
            }
            finally
            {
                if (p != null)
                {
                    p.Dispose();
                    p = null;
                }
            }
            return new WindowsProcessResult()
            {
                ExitCode = exitCode,
                StandardError = processError.ToString(),
                StandardOutput = processOutput.ToString()
            };
        }
    }
    public class WindowsProcessResult
    {
        public int ExitCode { get; set; }
        public string StandardOutput { get; set; }
        public string StandardError { get; set; }
    }
