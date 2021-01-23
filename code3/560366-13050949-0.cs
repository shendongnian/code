    private void button1_Click(object sender, RoutedEventArgs e)
    {
       DispatcherTimer timer = new DispatcherTimer();
       timer.Interval = new TimeSpan(0, 0, 5);
       timer.Tick += new EventHandler(timer_Tick);
       timer.Start();
    }
    
    void timer_Tick(object sender, EventArgs e)
    {
       t = t + dt;
       txt.Text = (t + dt).ToString();
    }
