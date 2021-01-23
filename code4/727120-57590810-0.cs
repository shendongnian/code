            FileSystemWatcher fsw = new FileSystemWatcher();
            string fullPath = "";
            DateTime tempTime;
            fsw.Path = @"C:\temp";
            private void startwatching()
            {
                timer1.Start();
            }
            fsw.EnableRaisingEvents = true;
            fsw.Created += Fsw_Created;
            private void Fsw_Created(object sender, FileSystemEventArgs e)
            {
                tempTime = DateTime.Now.AddSeconds(-4);
                fullPath = e.FullPath;
            }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fullPath!=string.Empty)
            {
                timer1.Stop();
                if (tempTime >= Directory.GetLastAccessTime(fullPath))
                {
                    DirectoryInfo di = new DirectoryInfo(fullPath);
                    listBox1.Items.Add("Folder " + di.Name + " finished copying");
                    fullPath = string.Empty;
                }
                else
                {
                    tempTime = DateTime.Now;
                }
                timer1.Start();
            }
        }
