            /// <summary>
        /// Method to run windows process
        /// </summary>
        /// <param name="processName">Process Name</param>
        /// <param name="arguments">Arguments </param>
        private void RunProcess(string processName, string arguments)
        {
            var newProcess = new ProcessStartInfo(processName);
            Log("User: " + GetSystemName());
            if (arguments.IsNotNullOrEmpty())
                newProcess.Arguments = arguments;
            newProcess.CreateNoWindow = false;
            newProcess.ErrorDialog = true;
            newProcess.RedirectStandardError = true;
            newProcess.RedirectStandardInput = true;
            newProcess.RedirectStandardOutput = true;
            newProcess.UseShellExecute = false;
            using (var proc = new Process())
            {
                proc.StartInfo = newProcess;
                proc.Start();
                Log(proc.StandardOutput.ReadToEnd());
            }
        }
