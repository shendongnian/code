            var myProcess = new Process();
            myProcess.StartInfo = new ProcessStartInfo(path, command);
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.EnableRaisingEvents = true;
            myProcess.OutputDataReceived += (object sendingProcess, DataReceivedEventArgs e) =>
            {
                if (e.Data != null)
                {
                    adbOutput.AppendLine(e.Data);
                }
            };
            myProcess.ErrorDataReceived += (object sendingProcess, DataReceivedEventArgs e) =>
            {
                if (e.Data != null)
                {
                    adbOutput.AppendLine(e.Data);
                }
            };
            myProcess.Start();
            verboseMethod();
            //Start Capture here!
            myProcess.BeginErrorReadLine();
            myProcess.BeginOutputReadLine();
            dllMethod();
