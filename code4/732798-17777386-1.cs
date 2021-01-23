    private void GoButton_Click(object sender, RoutedEventArgs e)
    {
        Hide();
        m_files = new CopyFilesWindow();
        m_files.Show();
        m_dispatcherTimer = new DispatcherTimer();
        m_dispatcherTimer.Tick += dispatcherTimer_Tick;
        m_dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
        m_dispatcherTimer.Start();
        SomeLongRunningTask.ContinueWith(() => 
        {
            // Executes this once SomeLongRunningTask is done (even if it raised an exception)
            m_files.Hide();
            Show();
        }, TaskScheduler.FromCurrentSynchronizationContext());  // This paramater is used to specify to run the lambda expression on the UI thread.
    }
