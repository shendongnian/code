    BackgroundWorker _worker = new BackgroundWorker();
    _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
       startButton.IsEnabled = false;
    }
     void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
     {
        stratButton.IsEnabled = true;
     }
    void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
      //Your processing code
    }
