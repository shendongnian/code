        /// <summary>
        /// Executes TFS commands by setting up TFS environment
        /// </summary>
        /// <param name="commands">TFS commands to be executed in sequence</param>
        /// <returns>Output stream for the commands</returns>
        private StreamReader ExecuteTfsCommand(string command)
        {
            logger.Info(string.Format("\n Executing TFS command: {0}",command));
            Process process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = _tFPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.Arguments = command;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();                                               // wait until process finishes   
            // log the error if there's any
            StreamReader errorReader = process.StandardError;
            if(errorReader.ReadToEnd()!="")
                logger.Error(string.Format(" \n Error in TF process execution ", errorReader.ReadToEnd()));
            return process.StandardOutput;
        }
