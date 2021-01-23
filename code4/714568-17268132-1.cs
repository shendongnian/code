    private DateTime _pauseTill = DateTime.MinValue;
    private void OnUpdate(object sender, object e)
    {
        // check if we are paused (i.e. "pause until" date has not been
        // reached yet
        if (_pauseTill > DateTime.Now)
        {
           return;
        }
        ...
    }
    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
        _pauseTill = DateTime.Now.AddMilliseconds(500);
    }
    
