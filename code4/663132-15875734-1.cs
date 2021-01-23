            BackgroundWorker backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += (s, args) =>
                {
                    Mydll.MyCfunction(ref curgen, ref dataindex);
                };
            backgroundWorker1.RunWorkerAsync();
            
            
            while (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.ReportProgress(curgen * 100 / ngen, "GEN");
                backgroundWorker1.ReportProgress(dataindex * 100 / (DIMENSION * FITNESSCASES), "DATA");
                
                backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
                Application.DoEvents();
            }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e1)
        {
            switch (e1.UserState.ToString())
            {
                case "GEN":
                    progressBar1.Value = e1.ProgressPercentage;
                    break;
                case "DATA":
                    progressBar2.Value = e1.ProgressPercentage;
                    break;
            }
        }
