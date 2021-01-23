        private void UpdateGroupPolicy()
        {
            FileInfo execFile = new FileInfo("gpupdate.exe");
            Process proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.FileName = execFile.Name;
            proc.StartInfo.Arguments = "/force";
            proc.Start();
            //Wait for GPUpdate to finish
            while (!proc.HasExited)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            MessageBox.Show("Update procedure has finished");
        }
