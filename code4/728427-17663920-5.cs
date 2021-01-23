    private void CheckBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
    	if (e.OriginalSource is BulletChrome)
    		e.Handled = false;
    	else
    		e.Handled = true;
    }
