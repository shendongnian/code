     private void exportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
       
            p.Start();
            p.BeginOutputReadLine();
            //p.WaitForExit();
            //p.Dispose();
        }
        private void UpdateTextBox(String message)
        {
            if (consoleOutputBox.InvokeRequired)
            {
                UpdateConsoleWindowDelegate update = new UpdateConsoleWindowDelegate(UpdateTextBox);
                consoleOutputBox.BeginInvoke(update, message);
            }
            else
            {
                consoleOutputBox.AppendText(message);
            }
        }
        void ConsoleOutputHandler(object sendingProcess, System.Diagnostics.DataReceivedEventArgs recieved)
        {
            if (!String.IsNullOrEmpty(recieved.Data))
            {
                UpdateTextBox(recieved.Data + "\n");
            }
        }
