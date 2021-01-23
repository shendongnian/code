    var worker = new BackgroundWorker();
    worker.DoWork += (s, e) =>
    {
        Thread.Sleep(1500); // Some processing
        Dispatcher.BeginInvoke(() => txMsg.Text = "Hello"); // Update the UI
        Thread.Sleep(1500); // More processing
    };
    worker.RunWorkerAsync();
