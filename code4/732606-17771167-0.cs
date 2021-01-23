    void (pagename)_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
    	if (!((bool)e.NewValue))
    	{
    		ap.Stop();
    	}
    }
