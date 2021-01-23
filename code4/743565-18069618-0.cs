    private void PersistDataToDb(object sender, RoutedEventArgs e)
    {
        worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += delegate(object o, DoWorkEventArgs args)
            {
                PersistDataToTable persistData = new PersistDataToTable();
                persistData.Persist(seriesId, worker.ReportProgress);
            };
        worker.ProgressChanged += delegate(object o, ProgressChangedEventArgs args)
            {
                int percentage = args.ProgressPercentage;
                progressBar.Value = percentage;
            };
        worker.RunWorkerAsync();
    }
    public class PersistDataToTable
    {
        public void Persist(int seriesId, Action<int> progresscallback)
        {
            // set the progress and call the Action(worker.ReportProgress)
            for (int i = 0; i < 100; i++)
            {
                progresscallback.Invoke(i);
            }
        }
    }
