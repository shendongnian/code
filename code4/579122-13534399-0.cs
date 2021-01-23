    DispatcherTimer m_dispatcherTimer = new DispatcherTimer();
    int m_count = 50;
    private void Init()
    {
        m_dispatcherTimer.Tick += new EventHandler(OnTick);
        m_dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
    }
    
    private void Create_Click(object sender, RoutedEventArgs e)
    {
        m_count = 50;
        m_dispatcherTimer.Start();
    }
    
    private void OnTick(object sender, EventArgs e)
    {
        // Draw your shapes here
        if(0>=--m_count)
        {
            m_dispatcherTimer.Stop();
        }
    }
