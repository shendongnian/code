    private void ImplementLongRunningOperation()
    {
      int id;
      string name;
      Task.Factory.StartNew(() =>
      {
        // our long-runing part. Getting id and name
        id = 42;
        name = "Jonh Doe";
      }).ContinueWith(t =>
        {
           // Handling results from the previous task.
           // This callback would be called in UI thread!
           label1.Text = id.ToString();
           label2.Text = name;
        }, TaskScheduler.FromSynchronizationContext);
    }
