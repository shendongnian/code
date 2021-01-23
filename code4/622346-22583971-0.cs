    private bool _isExplicitClose;
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
    	base.OnClosing(e);
    
    	if (!_isExplicitClose)
    	{
    		e.Cancel = true;
    		TaskbarIcon.Visibility = Visibility.Hidden;
    		Hide();
    	}
    }
