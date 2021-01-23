    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
          BackgroundWorker bgw = (BackgroundWorker)sender;
          if (bgw.CancellationPending)
          {
                e.Cancel = true;
                return;
          }
          else
          {
                radMax = GenerateDataFromNodes(rTNH, radMax);
                if (bgw.CancellationPending)
                {
                      e.Cancel = true;
                      return;
                }
                UpdateRenderRegion(); // draw result to cached bitmap
          }
    }
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
          if (!e.Cancelled)
               Invalidate();
          else
               Commence();
    }
    
    private void Commence()
    {
          if (worker.IsBusy)
          {
               worker.CancelAsync();
          }
          else
          {
               worker.RunWorkerAsync();
          }
    }
