    private bool _isExplicitClose;
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
    	base.OnClosing(e);
    
    	if (!_isExplicitClose)
    	{
    		e.Cancel = true;
    		Hide();
    	}
    }
    protected void QuitService(object sender, RoutedEventArgs e)
    {
       _isExplicitClose = true;
       TaskbarIcon.Visibility = Visibility.Hidden;
       Close();
    }
