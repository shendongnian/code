    public class ProcessWrapper
    {
        /// <summary>
        /// Output from stderr
        /// </summary>
        public string StdErr { get; private set; }
        /// <summary>
        /// Output from stdout
        /// </summary>
        public string StdOut { get; private set; }
        /// <summary>
        /// Starts a process
        /// </summary>
        /// <param name="command">Executable filename</param>
        /// <returns>Process exitcode</returns>
        public int Start(string command)
        {
            return Start(command, "");
        }
        /// <summary>
        /// Starts a process with commandline arguments
        /// </summary>
        /// <param name="command">Executable filename</param>
        /// <param name="arguments">Commanline arguments for the process</param>
        /// <returns>Process exitcode</returns>
        public int Start(string command, string arguments)
        {
            return Start(command, arguments, "");
        }
        /// <summary>
        /// Starts a process with commandline arguments and working directory
        /// </summary>
        /// <param name="command">Executable filename</param>
        /// <param name="arguments">Commanline arguments for the process</param>
        /// <param name="workingDirectory">Working directory for the process</param>
        /// <returns>Process exitcode</returns>
        public int Start(string command, string arguments, string workingDirectory)
        {
            StdErr = "";
            StdOut = "";
            var proc = new Process();
            proc.StartInfo.FileName = command;
            proc.StartInfo.Arguments = arguments;
            proc.StartInfo.WorkingDirectory = workingDirectory;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.EnableRaisingEvents = true;
            proc.StartInfo.CreateNoWindow = true;
            // Write messages from stderr to StdErr property
            proc.ErrorDataReceived += (sender, e) =>
            {
                StdErr += e.Data + Environment.NewLine;
            };
            // Write messages from stdout to StdOut property
            proc.OutputDataReceived += (sender, e) =>
            {
                StdOut += e.Data + Environment.NewLine;
            };
            proc.Start();
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            return proc.ExitCode;
        }
    }
