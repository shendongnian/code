    worker.DoWork += delegate(object sender, DoWorkEventArgs args)
    {
        // Loop through all the items
        for (int i = 0; i < items.Count - 1; i++)
        {
            // Create a slight delay and add each item to the Items collection
            Thread.Sleep(200);
            Deployment.Current.Dispatcher.BeginInvoke(
             () =>
                {
                    Items.Add(items[i]);
                });
        }
    };
    worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs args)
    {
    };
    worker.RunWorkerAsync();
