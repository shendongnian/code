        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (filesContent.Length > 0)
            {
                for (int i = 0; i < filesContent.Length; i++)
                {
                    if (worker.CancellationPending)
                    {
                       e.Cancel = true;
                       return;
                    }  
                    File.Copy(filesContent[i], Path.Combine(contentDirectory, Path.GetFileName(filesContent[i])), true);
                }
            }
            if (!worker.CancellationPending)
                WindowsUpdate();
            if (!worker.CancellationPending)
               CreateDriversList();
            if (!worker.CancellationPending)
               GetHostsFile();
            if (!worker.CancellationPending)
               Processes();
            if (worker.CancellationPending)
                e.Cancel = true;
        }
