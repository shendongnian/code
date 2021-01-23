    void RunLongProcess(SomeViewModel someDataObject)
    {
        for (int i = 0; i <= 1000; i++)
        {
            Thread.Sleep(10);
            // Update every 10 executions
            if (i % 10 == 0)
            {
                // Send message to UI thread
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    (Action)(() => someDataObject.ProgressValue = (i / 1000)));
            }
        }
    }
