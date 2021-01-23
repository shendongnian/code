    private void worker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.progressBar1.Value = 0;
      Thread.Sleep(1000);
      if (worker2.IsBusy != true)
      {
        worker2.RunWorkerAsync();
      }
    }
