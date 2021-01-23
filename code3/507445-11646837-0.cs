    // I usually disable controls (buttons, etc.)
    // so user is prevented to perform other
    // actions
    BackgroundWorker worker = new BackgroundWorker();
    worker.DoWork += (s, e) =>
    {
         // Get the parameter
         var param = e.Argument as <your expected object>
         // Perform parsing
    }
    worker.RunWorkerCompleted += (s1, e1) =>
    {
         System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(
            new Action(() =>
            {
                 // enable you controls here
            }));
    }
    worker.RunWorkerAsync(parameter);
