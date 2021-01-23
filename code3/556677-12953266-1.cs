    public void YourFunction()
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += (sender, args) =>
          {
             ...do your long running operation
          };
        
        bw.RunWorkerCompleted += (sender, args) =>
          { 
             Dispatcher.BeginInvoke(...close your view here);
          }
    
        bw.RunWorkerAsync();
    }
