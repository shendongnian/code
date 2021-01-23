    void RunLongProcess(Dispatcher uiDispatcher, ProgressBar progressBar)
    {
        for (int i = 0; i <= 100; i++)
        {
            Thread.Sleep(10);
            if (i % 10 == 0)
            {
                // Send message to UI thread
                uiDispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (Action)(() => progressBar.Value = i));
                Debug.WriteLine(i.ToString());
            }
        }
    }
