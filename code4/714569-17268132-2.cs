    private bool _paused = false;
    private void OnUpdate(object sender, object e)
    {
        if (_paused)
        {
           return;
        }
        ...
    }
    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
        _paused != _paused;
    }
    
