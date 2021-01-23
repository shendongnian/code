    public void YourFunction(Dispatcher dispatcher)
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += (sender, args) =>
          {
             ...do your long running operation
          };
        
        bw.RunWorkerCompleted += (sender, args) =>
          { 
             dispatcher.BeginInvoke(...close your view here);
          }
    
        bw.RunWorkerAsync();
    }
