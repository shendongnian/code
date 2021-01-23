    public void FirstMenuItem_Click(object sender, RoutedEventArgs e)
    {
        CheckDataShowWindow();
    }
    private bool AllReadyWaiting = false;
    private void CheckDataShowWindow()
    {
        if (!DataRepository.IsAllDataLoaded)
        {
            if(!AllReadyWaiting)
            {
                DataRepository.DoneLoading += (s,e) => ShowWindow();
                AllReadyWaiting = true;
            }
        }
        else
        {
            ShowWindow();
        }
    }
    private void ShowWindow()
    {
        Dispatcher.BeginInvoke(new Action(() =>
        {
            IndividualEntryWindow Window = new IndividualEntryWindow();
            Window.Show();
        }));
    }
