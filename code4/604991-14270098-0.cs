    private void PanoControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    
    	if (PanoControl.SelectedIndex == 0)
    		this.ApplicationBar.IsVisible = false;
    	else if(PanoControl.SelectedIndex == 1)
    		((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).IsEnabled = false;
    	else if (PanoControl.SelectedIndex == 2)
    	{
    		this.ApplicationBar.IsVisible = false;
    		((ApplicationBarMenuItem)ApplicationBar.MenuItems[0]).IsEnabled = false;
    	}
    }
