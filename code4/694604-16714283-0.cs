    public void FirstMenuItem_Click(object sender, RoutedEventArgs e)
    {
        CheckDataShowWindow();
    }
    private void CheckDataShowWindow()
    {
        if (!DataRepository.IsAllDataLoaded)
        {
            Timer t = new Timer();
            t.Interval = 0.2;
            t.AutoReset = false; 
            t.Elapsed += (s,e) => CheckDataShowWindow();
            t.Start();
        }
        else
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                IndividualEntryWindow Window = new IndividualEntryWindow();
                Window.Show();
            }));
        }
    }
