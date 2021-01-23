    DispatcherTimer timer1 = new DispatcherTimer();
    void bTime_Click(object sender, RoutedEventArgs e)
    {
        timer1.Interval = TimeSpan.FromSeconds(60);
        timer1.Tick += new EventHandler(timer_Tick);
        timer1.Start();
    }
    int tik = 60;
    void timer_Tick(object sender, EventArgs e)
    {
        bTime.Content = tik.ToString();
        if (tik > 0)
            Countdown.Text = (tik--).ToString();
        else
        {
            Countdown.Text = "Times Up";
            timer1.Stop();
        }
        throw new NotImplementedException();
    }
    
